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
    public class Mathang_Deleted_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.MATHANG> _List;

        public ObservableCollection<Model.MATHANG> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.MATHANG> _RDList;

        public ObservableCollection<Model.MATHANG> RDList
        {
            get { return _RDList; }
            set { _RDList = value; OnPropertyChanged(); }
        }

        private Model.MATHANG _SelectedItem;

        public Model.MATHANG SelectedItem
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

        #region Commands Sap xep

        public ICommand OrderbyTenMathang_Command { get; set; }
        public ICommand OrderbyTennhacungcap_Command { get; set; }
        public ICommand OrderbyTenloai_Command { get; set; }
        public ICommand OrderbyTendonvi_Command { get; set; }

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

        public Mathang_Deleted_ViewModel()
        {
            List = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == true));
            RDList = new ObservableCollection<Model.MATHANG>();

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
                SelectedItem = Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.ma_mathang == id).SingleOrDefault();
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
                SelectedItem = Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.ma_mathang == id).SingleOrDefault();
            });

            Delete_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Model.Mathang_Service.Delete(SelectedItem);
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
                RDList.Add(List.Where(x => x.ma_mathang == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveRDList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                RDList.Remove(List.Where(x => x.ma_mathang == p.Uid.ToString()).SingleOrDefault());
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

                RDList = new ObservableCollection<Model.MATHANG>();
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

                RDList = new ObservableCollection<Model.MATHANG>();
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
                List = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == true));

                if (!string.IsNullOrEmpty(str))
                {
                    var filterlist = List.Where(x => x.ma_mathang.Contains(str) || x.ten_mathang.Contains(str) || x.NHACUNGCAP.ten_nhacungcap.Contains(str)
                        || x.LOAIHANG.ten_loaihang.Contains(str) || x.hang.Contains(str) || x.dong.Contains(str));

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
                    List = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == true));
                }
            });

            #endregion

            #region Phan sap xep

            OrderbyTenMathang_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.MATHANG> chkList = new ObservableCollection<Model.MATHANG>(List.OrderByDescending(x => x.ten_mathang));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.MATHANG>(List.OrderBy(x => x.ten_mathang));
                }
                else
                {
                    List = new ObservableCollection<Model.MATHANG>(chkList);
                }
            });

            OrderbyTennhacungcap_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.MATHANG> chkList = new ObservableCollection<Model.MATHANG>(List.OrderByDescending(x => x.NHACUNGCAP.ten_nhacungcap));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.MATHANG>(List.OrderBy(x => x.NHACUNGCAP.ten_nhacungcap));
                }
                else
                {
                    List = new ObservableCollection<Model.MATHANG>(chkList);
                }
            });

            OrderbyTenloai_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.MATHANG> chkList = new ObservableCollection<Model.MATHANG>(List.OrderByDescending(x => x.LOAIHANG.ten_loaihang));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.MATHANG>(List.OrderBy(x => x.LOAIHANG.ten_loaihang));
                }
                else
                {
                    List = new ObservableCollection<Model.MATHANG>(chkList);
                }
            });

            OrderbyTendonvi_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.MATHANG> chkList = new ObservableCollection<Model.MATHANG>(List.OrderByDescending(x => x.DONVITINH.ten_donvi));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.MATHANG>(List.OrderBy(x => x.DONVITINH.ten_donvi));
                }
                else
                {
                    List = new ObservableCollection<Model.MATHANG>(chkList);
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
                foreach (var item in Model.DataProvider.Ins.DB.MATHANGs.ToList())
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
                foreach (var item in Model.DataProvider.Ins.DB.MATHANGs)
                {
                    while (item == RDList[i])
                    {
                        Model.Mathang_Service.Delete(item);
                        break;
                    }
                }
            }
            Model.DataProvider.Ins.DB.SaveChanges();
        }
        #endregion
    }
}
