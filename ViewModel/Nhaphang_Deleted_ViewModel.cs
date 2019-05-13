using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLK_Dn.ViewModel
{
    public class Nhaphang_Deleted_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.CHITIETPHIEUNHAP> _List;

        public ObservableCollection<Model.CHITIETPHIEUNHAP> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.CHITIETPHIEUNHAP> _RDList;

        public ObservableCollection<Model.CHITIETPHIEUNHAP> RDList
        {
            get { return _RDList; }
            set { _RDList = value; OnPropertyChanged(); }
        }

        private Model.CHITIETPHIEUNHAP _SelectedItem;

        public Model.CHITIETPHIEUNHAP SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }

        #region Commands
        public ICommand Delete_Command { get; set; }
        public ICommand Restore_Command { get; set; }
        public ICommand Del_Command { get; set; }
        public ICommand Res_Command { get; set; }
        public ICommand AddRDList_Command { get; set; }
        public ICommand RemoveRDList_Command { get; set; }
        public ICommand DeleteShow_Command { get; set; }
        public ICommand RestoreShow_Command { get; set; }
        public ICommand DelShow_Command { get; set; }
        public ICommand ResShow_Command { get; set; }
        public ICommand Search_Command { get; set; }

        #endregion

        #region Dialog
        private bool _Openres;

        public bool Openres
        {
            get { return _Openres; }
            set { _Openres = value; OnPropertyChanged(); }
        }

        private bool _Opendel;

        public bool Opendel
        {
            get { return _Opendel; }
            set { _Opendel = value; OnPropertyChanged(); }
        }

        private bool _Openrestore;

        public bool Openrestore
        {
            get { return _Openrestore; }
            set { _Openrestore = value; OnPropertyChanged(); }
        }

        private bool _Opendelete;

        public bool Opendelete
        {
            get { return _Opendelete; }
            set { _Opendelete = value; OnPropertyChanged(); }
        }

        private string _Content;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; OnPropertyChanged(); }
        }


        public ICommand CloseDialog_Command { get; set; }
        #endregion

        public Nhaphang_Deleted_ViewModel()
        {
            List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.IsDeleted == true).ToList().OrderByDescending(x => MySource.MyStaticMethods.ConvertStringtoDate(x.PHIEUNHAP.ngaynhap)));
            RDList = new ObservableCollection<Model.CHITIETPHIEUNHAP>();

            Opendel = false;
            Openres = false;
            Opendelete = false;
            Openrestore = false;

            Content = string.Empty;
            SelectedItem = null;

            CloseDialog_Command = new RelayCommand<MaterialDesignThemes.Wpf.DialogHost>(p =>
            {
                return true;
            }, p =>
            {
                p.IsOpen = false;
            });

            #region Khoi phuc/ Xoa 1 dong
            DeleteShow_Command = new RelayCommand<Button>(p =>
            {
                if (Openrestore == true || Opendelete == true || Openres == true || Opendel == true)
                    return false;

                return true;
            }, p =>
            {
                Opendelete = true;
                Content = " Xóa vĩnh viễn bản ghi này";

                string id = p.Uid.ToString();
                SelectedItem = Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.ma_ctphieunhap == id).SingleOrDefault();
            });

            RestoreShow_Command = new RelayCommand<Button>(p =>
            {
                if (Openrestore == true || Opendelete == true || Openres == true || Opendel == true)
                    return false;

                return true;
            }, p =>
            {
                Openrestore = true;
                Content = " Khôi phục bản ghi này";

                string id = p.Uid.ToString();
                SelectedItem = Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.ma_ctphieunhap == id).SingleOrDefault();
            });

            Delete_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Model.Nhaphang_Service.Delete(SelectedItem);
                Model.DataProvider.Ins.DB.SaveChanges();

                List.Remove(SelectedItem);
                Opendelete = false;
            });

            Restore_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                SelectedItem.IsDeleted = false;
                Model.DataProvider.Ins.DB.SaveChanges();

                List.Remove(SelectedItem);
                Openrestore = false;
            });
            #endregion

            #region Khoi phuc / Xoa nhieu dong

            AddRDList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                RDList.Add(List.Where(x => x.ma_ctphieunhap == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveRDList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                RDList.Remove(List.Where(x => x.ma_ctphieunhap == p.Uid.ToString()).SingleOrDefault());
            });

            ResShow_Command = new RelayCommand<object>(p =>
            {
                if (RDList.Count() == 0)
                    return false;

                if (Openrestore == true || Opendelete == true || Openres == true || Opendel == true)
                    return false;

                return true;
            }, p =>
            {
                Openres = true;
                Content = " Khôi phục tất cả các bản ghi được chọn";
            });

            Res_Command = new RelayCommand<object>(p =>
            {
                if (RDList.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                Restone_IteminDb();
                RemoveIteminList();

                RDList = new ObservableCollection<Model.CHITIETPHIEUNHAP>();
                Openres = false;
            });

            DelShow_Command = new RelayCommand<object>(p =>
            {
                if (RDList.Count() == 0)
                    return false;

                if (Openrestore == true || Opendelete == true || Openres == true || Opendel == true)
                    return false;

                return true;
            }, p =>
            {
                Opendel = true;
                Content = " Xóa vĩnh viễn tất cả các bản ghi được chọn";
            });

            Del_Command = new RelayCommand<object>(p =>
            {
                if (RDList.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                Removeforever_IteminDb();
                RemoveIteminList();

                RDList = new ObservableCollection<Model.CHITIETPHIEUNHAP>();
                Opendel = false;
            });
            #endregion

            #region Phan tim kiem

            Search_Command = new RelayCommand<TextBox>(p =>
            {
                return true;
            }, p =>
            {
                string str = p.Text;
                List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.IsDeleted == true));


                if (!string.IsNullOrEmpty(str))
                {
                    var filterlist = List.Where(x => x.MATHANG.ten_mathang.Contains(str) || x.MATHANG.NHACUNGCAP.ten_nhacungcap.Contains(str)
                                     || x.MATHANG.DONVITINH.ten_donvi.Contains(str) || x.MATHANG.LOAIHANG.ten_loaihang.Contains(str) || x.PHIEUNHAP.ngaynhap.Contains(str));

                    for (int i = 0; i < List.Count(); i++)
                    {
                        while (!filterlist.Contains(List[i]))
                        {
                            if (List[i] == List[List.Count() - 1])
                            {
                                List.Remove(List[i]);
                                break;
                            }
                            else
                            {
                                List.Remove(List[i]);
                            }
                        }
                    }
                }
                else
                {
                    List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.IsDeleted == true));
                }
            });

            #endregion
        }

        #region Methods
        private void RemoveIteminList()
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (RDList.Where(x => x == List[i]).Count() != 0)
                {
                    if (List[i] == List[List.Count() - 1])
                    {
                        List.Remove(List[i]);
                        break;
                    }
                    else
                    {
                        List.Remove(List[i]);
                    }
                };
            }
        }

        private void Restone_IteminDb()
        {
            for (int i = 0; i < RDList.Count(); i++)
            {
                foreach (var item in Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.ToList())
                {
                    while (item == RDList[i])
                    {
                        item.IsDeleted = false;
                        Model.DataProvider.Ins.DB.SaveChanges();
                        break;
                    }
                }
            }

        }

        private void Removeforever_IteminDb()
        {
            for (int i = 0; i < RDList.Count(); i++)
            {
                foreach (var item in Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs)
                {
                    while (item == RDList[i])
                    {
                        Model.Nhaphang_Service.Delete(item);
                        break;
                    }
                }
            }
            Model.DataProvider.Ins.DB.SaveChanges();
        }
        #endregion
    }
}
