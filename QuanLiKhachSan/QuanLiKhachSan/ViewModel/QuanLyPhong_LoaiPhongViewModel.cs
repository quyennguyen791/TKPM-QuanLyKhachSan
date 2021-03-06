﻿using Microsoft.Win32;
using QuanLiKhachSan.Model;
using QuanLiKhachSan.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLiKhachSan.ViewModel
{
    public class QuanLyPhong_LoaiPhongViewModel : BaseViewModel
    {
        // Quan Ly Loai Phong
        private bool isAddRoom = true;
        private bool _choPhepDoi = true;
        public bool choPhepThayDoi { get => _choPhepDoi; set => OnPropertyChanged(ref _choPhepDoi, value); }
        private string _timLoaiInput;
        public string timLoaiPhongInput { get => _timLoaiInput; set => OnPropertyChanged(ref _timLoaiInput, value); }
        public ICommand timLoaiPhongCommand { get; set; }
        public ICommand confirmButtonCommmand { get; set; }
        public ICommand cancelButtonCommmand { get; set; }
        public ICommand addPhongCommand { get; set; }
        public ICommand exportLoaiPhongCommand { get; set; }
        public ICommand importLoaiPhongCommand { get; set; }
        public ICommand exportPhongCommand { get; set; }
        public ICommand importPhongCommand { get; set; }
        private string _cancelButtonName = "HỦY";
        private string _confirmButtonName = "THÊM";
        public string cancelButtonName
        {
            get => _cancelButtonName;
            set
            {
                _cancelButtonName = value;
                OnPropertyChanged();
            }
        }
        public string confirmButtonName
        {
            get => _confirmButtonName;
            set
            {
                _confirmButtonName = value;
                OnPropertyChanged();
            }
        }
        private BindingList<LOAIPHONG> _listLoaiPhong;
        public BindingList<LOAIPHONG> listLoaiPhong
        {
            get
            {
                return _listLoaiPhong;
            }
            set
            {
                _listLoaiPhong = value;
                OnPropertyChanged();
            }
        }
        private string _maLoai;
        public string txtMaLoai { get => _maLoai; set => OnPropertyChanged(ref _maLoai, value); }
        private string _tenLoai;
        public string txtTen { get => _tenLoai; set => OnPropertyChanged(ref _tenLoai, value); }
        private DateTime _NgayTao;
        public DateTime txtNgayTao { get => _NgayTao; set => OnPropertyChanged(ref _NgayTao, value); }
        private LOAIPHONG item { get; set; }
        public LOAIPHONG selectItem
        {
            get { return item; }
            set
            {
                if (item != value)
                {
                    item = value;
                    showDetails();
                }
            }
        }
        public void showDetails()
        {

            if (selectItem != null)
            {
                choPhepThayDoi = false;
                txtMaLoai = selectItem.LoaiPhongID;
                txtTen = selectItem.TenLoai;
                txtNgayTao = selectItem.NgayTao;
                isAddRoom = false;
                cancelButtonName = "XÓA";
                confirmButtonName = "LƯU";
            }
            else
            {
                isAddRoom = true;
                choPhepThayDoi = true;
                cancelButtonName = "HỦY";
                confirmButtonName = "THÊM";
            }
        }
        private void reset()
        {
            isAddRoom = true;
            choPhepThayDoi = true;
            cancelButtonName = "HỦY";
            confirmButtonName = "THÊM";
            txtTen = string.Empty;
            txtMaLoai = string.Empty;
        }

        // Quan Ly Phong

        private string _currentSelectLoaiPhong;
        public string currentSelectLoaiPhong { get => _currentSelectLoaiPhong; set => OnPropertyChanged(ref _currentSelectLoaiPhong, value); }
        private bool isAddnewRoom = true;
        private bool _choPhepUpdateRoom = true;
        public bool choPhepUpdateRoom { get => _choPhepUpdateRoom; set => OnPropertyChanged(ref _choPhepUpdateRoom, value); }
        private string _timPhongInput;
        public string timPhongInput { get => _timPhongInput; set => OnPropertyChanged(ref _timPhongInput, value); }
        public ICommand timPhongCommand { get; set; }
        public ICommand comfirmRoomBtnCommand { get; set; }
        public ICommand cancelRoomBtnCommand { get; set; }
        public ICommand addNewRoomCommand { get; set; }
        private string _roomCancelBtnName = "HỦY";
        private string _roomConfirmBtnName = "THÊM";
        public string roomCancelBtnName
        {
            get => _roomCancelBtnName;
            set
            {
                _roomCancelBtnName = value;
                OnPropertyChanged();
            }
        }
        public string roomConfirmBtnName
        {
            get => _roomConfirmBtnName;
            set
            {
                _roomConfirmBtnName = value;
                OnPropertyChanged();
            }
        }
        private BindingList<PHONG> _listPhong;
        public BindingList<PHONG> listPhong
        {
            get
            {
                return _listPhong;
            }
            set
            {
                _listPhong = value;
                OnPropertyChanged();
            }
        }
        private string _tenPhong;
        public string txtTenPhong { get => _tenPhong; set => OnPropertyChanged(ref _tenPhong, value); }
        private double _donGia;
        public double txtDonGia { get => _donGia; set => OnPropertyChanged(ref _donGia, value); }
        private string _IDphong;
        public string txtPhmgID { get => _IDphong; set => OnPropertyChanged(ref _IDphong, value); }
        // true --> Chua , false --> Da thue
        private bool _boolTinhTrangThue;
        public bool boolTinhTrangThue { get => _boolTinhTrangThue; set => OnPropertyChanged(ref _boolTinhTrangThue, value); }

        private string _tinhTrangThue;
        public string txtTinhTrangThuePhong { get => _tinhTrangThue; set => OnPropertyChanged(ref _tinhTrangThue, value); }
        private DateTime _ngayTaoPhong;
        public DateTime txtNgayTaoPhong { get => _ngayTaoPhong; set => OnPropertyChanged(ref _ngayTaoPhong, value); }
        private PHONG itemPhong { get; set; }
        public PHONG selectPhong
        {
            get { return itemPhong; }
            set
            {
                if (itemPhong != value)
                {
                    itemPhong = value;
                    showDetailsPhong();
                }
            }
        }
        //chonLoaiPhongSelectedItem
        private LOAIPHONG _itemLoaiPhongChon { get; set; }
        public LOAIPHONG itemLoaiPhongChon
        {
            get { return _itemLoaiPhongChon; }
            set
            {
                if (_itemLoaiPhongChon != value)
                {
                    _itemLoaiPhongChon = value;
                }
            }
        }
        public void showDetailsPhong()
        {

            if (selectPhong != null)
            {
                choPhepUpdateRoom = !selectPhong.TinhTrangThue;  //! Chưa thuê --> Bật --> TinhTrangThue = true <--> Chưa thuê
                currentSelectLoaiPhong = selectPhong.LOAIPHONG.TenLoai;
                isAddnewRoom = false;
                txtTenPhong = selectPhong.TenPhong;
                txtDonGia = selectPhong.DonGia;
                txtNgayTaoPhong = selectPhong.NgayTao;
                txtPhmgID = selectPhong.PhongID;
                if (selectPhong.TinhTrangThue == true)
                {
                    txtTinhTrangThuePhong = "Đã thuê";
                    boolTinhTrangThue = true;
                }
                else
                {
                    txtTinhTrangThuePhong = "Chưa thuê";
                    boolTinhTrangThue = false;
                }
                roomCancelBtnName = "XÓA";
                roomConfirmBtnName = "LƯU";
            }
            else
            {
                resetRoom();
            }
            // DisplayedImagePath = selectItem.HINHANH;
        }
        private void resetRoom()
        {
            isAddnewRoom = true;
            itemLoaiPhongChon = null;
            choPhepUpdateRoom = true;
            currentSelectLoaiPhong = "Chọn loại phòng";
            txtTenPhong = string.Empty;
            txtDonGia = 0;
            txtTinhTrangThuePhong = "Chưa thuê";
            boolTinhTrangThue = false;
            txtPhmgID = null;
            itemLoaiPhongChon = null;
            roomCancelBtnName = "HỦY";
            roomConfirmBtnName = "THÊM";

        }
        private bool checkCondition()
        {
            try
            {
                return (itemLoaiPhongChon == null || string.IsNullOrEmpty(txtTenPhong) || string.IsNullOrEmpty(txtTinhTrangThuePhong) || string.IsNullOrEmpty(txtPhmgID) ||
            string.IsNullOrEmpty(txtDonGia.ToString()));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public QuanLyPhong_LoaiPhongViewModel()
        {
            listLoaiPhong = new BindingList<LOAIPHONG>(DatabaseQueryTN.danhsachLoaiPhong());
            listPhong = new BindingList<PHONG>(DatabaseQueryTN.danhSachPhong());
            exportLoaiPhongCommand = new RelayCommand<Object>((P) => { return true; }, (p) =>
            {
                ConcreteModelFactory ModelFactory = new ConcreteModelFactory();
                Window w = ((Window)p);
                SaveFileDialog openFileDialog = new SaveFileDialog();
                string name = "";
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls";
                if (openFileDialog.ShowDialog() == true)
                {
                    name = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
                ManHinhLoading wd = new ManHinhLoading();
                w.Dispatcher.Invoke(() =>
                {
                    wd.Show();
                });
                IModelName modelName = ModelFactory.Factory("LOAIPHONG", name);
                Thread.Sleep(200);
                Thread newWindowThread = new Thread(() =>
                {
                    modelName.exportExcel();
                    w.Dispatcher.Invoke(() =>
                    {
                        wd.Close();
                    });
                });
                newWindowThread.Start();
            });
            importLoaiPhongCommand = new RelayCommand<Object>((P) => { return true; }, (p) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls";
                string name = "";
                if (openFileDialog.ShowDialog() == true)
                {
                    name = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
                Window w = ((Window)p);
                ManHinhLoading wd = new ManHinhLoading();
                w.Dispatcher.Invoke(() =>
                {
                    wd.Show();
                });
                ConcreteModelFactory ModelFactory = new ConcreteModelFactory();
                IModelName modelName = ModelFactory.Factory("LOAIPHONG", name);
                Thread newWindowThread = new Thread(() =>
                {
                    w.Dispatcher.Invoke(() =>
                    {
                        modelName.importExcel();
                    });
                    listLoaiPhong = new BindingList<LOAIPHONG>(DatabaseQueryTN.danhsachLoaiPhong());
                    listPhong = new BindingList<PHONG>(DatabaseQueryTN.danhSachPhong());
                    w.Dispatcher.Invoke(() =>
                    {
                        wd.Close();
                    });
                });
                newWindowThread.Start();
                //ConcreteModelFactory ModelFactory = new ConcreteModelFactory();
                //IModelName modelName = ModelFactory.Factory("LOAIPHONG", "");
                //modelName.importExcel();
                //listLoaiPhong = new BindingList<LOAIPHONG>(DatabaseQueryTN.danhsachLoaiPhong());
                //listPhong = new BindingList<PHONG>(DatabaseQueryTN.danhSachPhong());

            });
            exportPhongCommand = new RelayCommand<Object>((P) => { return true; }, (p) =>
            {
                ConcreteModelFactory ModelFactory = new ConcreteModelFactory();
                Window w = ((Window)p);
                SaveFileDialog openFileDialog = new SaveFileDialog();
                string name = "";
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls";
                if (openFileDialog.ShowDialog() == true)
                {
                    name = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
                ManHinhLoading wd = new ManHinhLoading();
                w.Dispatcher.Invoke(() =>
                {
                    wd.Show();
                });
                IModelName modelName = ModelFactory.Factory("PHONG", name);
                Thread.Sleep(200);
                Thread newWindowThread = new Thread(() =>
                {
                    modelName.exportExcel();
                    w.Dispatcher.Invoke(() =>
                    {
                        wd.Close();
                    });
                });
                newWindowThread.Start();
            });
            importPhongCommand = new RelayCommand<Object>((P) => { return true; }, (p) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls";
                string name = "";
                if (openFileDialog.ShowDialog() == true)
                {
                    name = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
                Window w = ((Window)p);
                ManHinhLoading wd = new ManHinhLoading();
                w.Dispatcher.Invoke(() =>
                {
                    wd.Show();
                });
                ConcreteModelFactory ModelFactory = new ConcreteModelFactory();
                IModelName modelName = ModelFactory.Factory("PHONG", name);
                Thread newWindowThread = new Thread(() =>
                {
                    w.Dispatcher.Invoke(() =>
                    {
                        modelName.importExcel();
                    });
                    listPhong = new BindingList<PHONG>(DatabaseQueryTN.danhSachPhong());
                    w.Dispatcher.Invoke(() =>
                    {
                        wd.Close();
                    });
                });
                newWindowThread.Start();
                //ConcreteModelFactory ModelFactory = new ConcreteModelFactory();
                //IModelName modelName = ModelFactory.Factory("PHONG", "");
                //modelName.importExcel();
                //listPhong = new BindingList<PHONG>(DatabaseQueryTN.danhSachPhong());

            });
            timLoaiPhongCommand = new RelayCommand<Object>((P) => { return true; }, (p) =>
            {
                listLoaiPhong = new BindingList<LOAIPHONG>(DatabaseQueryTN.timKiemLoaiPhong(timLoaiPhongInput));
            });
            timPhongCommand = new RelayCommand<Object>((P) => { return true; }, (p) =>
            {
                listPhong = new BindingList<PHONG>(DatabaseQueryTN.timKiemPhong(timPhongInput));
            });
            // CLick button add
            addPhongCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                isAddRoom = true;
                reset();
                DatabaseQuery.capNhatCSDL();
            });
            // them moi phong
            addNewRoomCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                resetRoom();
                DatabaseQuery.capNhatCSDL();
            });
            // THEM MOI / CAP NHAT
            // 1. PHONG

            comfirmRoomBtnCommand = new RelayCommand<Object>((p) =>
            {
                //
                // txtTinhTrangThuePhong = "Chưa thuê";
                if (checkCondition()) return false;
                return true;
            }, (p) =>
            {
                PHONG newLP = new PHONG();
                newLP.PhongID = txtPhmgID;
                newLP.LoaiPhongID = itemLoaiPhongChon.LoaiPhongID;
                newLP.TenPhong = txtTenPhong;
                newLP.DonGia = txtDonGia;
                newLP.TinhTrangThue = boolTinhTrangThue;
                // Neu dang o che do them User
                if (isAddnewRoom)
                {
                    if (DatabaseQueryTN.kiemTraTonTaiPhong(txtPhmgID))
                    {
                        DatabaseQuery.MyMessageBox("Phòng đã tồn tại");
                        return;

                    }
                    try
                    {
                        DatabaseQueryTN.themMoiPhong(newLP);
                        DatabaseQuery.MyMessageBox("Thêm mới phòng thành công");
                        listPhong = new BindingList<PHONG>(DatabaseQueryTN.danhSachPhong());
                    }
                    catch (Exception e)
                    {
                        SecurityModel.Log(e.ToString());
                        DatabaseQuery.MyMessageBox("Không thể thêm phòng ");
                    }
                }
                else // Cap Nhat
                {
                    try
                    {
                        newLP.TinhTrangTonTai = false;
                        DatabaseQueryTN.capNhatPhong(newLP);
                        listPhong = new BindingList<PHONG>(DatabaseQueryTN.danhSachPhong());
                        DatabaseQuery.MyMessageBox("Đã cập nhật phòng");

                    }
                    catch (Exception e)
                    {

                        SecurityModel.Log(e.ToString());
                        DatabaseQuery.MyMessageBox("Không thể cập nhật loại phòng.");
                    }
                    //showDetails();
                }
            });

            confirmButtonCommmand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(txtMaLoai) ||
                string.IsNullOrEmpty(txtTen))
                    return false;
                return true;
            }, (p) =>
            {
                LOAIPHONG newLP = new LOAIPHONG();
                newLP.LoaiPhongID = txtMaLoai;
                newLP.TenLoai = txtTen;
                // Neu dang o che do them User
                if (isAddRoom)
                {
                    if (DatabaseQueryTN.kiemTraTonTaiLoaiPhong(txtMaLoai))
                    {
                        DatabaseQuery.MyMessageBox("Loại phòng đã tồn tại");
                        return;
                        //if (!DatabaseQueryTN.isDeleteRoom(txtMaLoai)) // true --> delete
                        //{
                        //}

                    }
                    try
                    {
                        DatabaseQueryTN.themMoiLoaiPhong(newLP);
                        DatabaseQuery.MyMessageBox("Thêm mới phòng thành công. ");
                        listLoaiPhong = new BindingList<LOAIPHONG>(DatabaseQueryTN.danhsachLoaiPhong());
                    }
                    catch (Exception e)
                    {
                        SecurityModel.Log(e.ToString());
                        DatabaseQuery.MyMessageBox("Không thể thêm loại phòng ");
                    }
                }
                else // Cap Nhat
                {
                    try
                    {
                        newLP.TinhTrang = false;
                        DatabaseQueryTN.capNhatLoaiPhong(newLP);
                        listLoaiPhong = new BindingList<LOAIPHONG>(DatabaseQueryTN.danhsachLoaiPhong());
                        DatabaseQuery.MyMessageBox("Đã cập nhật loại phòng");

                    }
                    catch (Exception e)
                    {
                        SecurityModel.Log(e.ToString());
                        DatabaseQuery.MyMessageBox("Không thể cập nhật loại phòng.");
                    }
                    //showDetails();
                }
            });

            // Huỷ Thêm hoặc Xoá
            // 1. Loai Phong Huy / Xoa
            cancelButtonCommmand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                if (isAddRoom)
                {
                    try
                    {
                        reset();
                        DatabaseQuery.capNhatCSDL();
                    }
                    catch (Exception) { };
                    return;
                }
                else
                {
                    try
                    {
                        if (DatabaseQueryTN.isUsedLoaiPhong(selectItem.LoaiPhongID))
                        {

                            DatabaseQuery.MyMessageBox("Loại phòng đã có phòng cho thuê. Không thể xoá");
                            return;
                        }
                        DatabaseQueryTN.xoaLoaiPhong(selectItem);
                        DatabaseQuery.MyMessageBox("Đã xoá loại phòng này");
                        listLoaiPhong = new BindingList<LOAIPHONG>(DatabaseQueryTN.danhsachLoaiPhong());
                        listPhong = new BindingList<PHONG>(DatabaseQueryTN.danhSachPhong());
                        reset();
                    }
                    catch (Exception e)
                    {
                        SecurityModel.Log(e.ToString());
                        DatabaseQuery.MyMessageBox("Không thể xoá loại phòng này");
                    }
                }
            });
            // 2. Phong Huy / Xoa
            cancelRoomBtnCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                if (isAddnewRoom)
                {
                    try
                    {
                        resetRoom();
                        DatabaseQuery.capNhatCSDL();
                    }
                    catch (Exception) { };
                    return;
                }
                else
                {
                    try
                    {
                        DatabaseQueryTN.xoaPhong(selectPhong);
                        DatabaseQuery.MyMessageBox("Đã xoá phòng này");
                        listPhong = new BindingList<PHONG>(DatabaseQueryTN.danhSachPhong());
                        resetRoom();
                    }
                    catch (Exception e)
                    {
                        SecurityModel.Log(e.ToString());
                        DatabaseQuery.MyMessageBox("Không thể xoá phòng này");
                    }
                }
            });
        }
    }
}
