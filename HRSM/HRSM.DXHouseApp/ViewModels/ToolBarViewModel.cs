using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HRSM.DXHouseApp.ViewModels
{
    public class ToolBarViewModel:ViewModelBase
    {
        public ToolBarViewModel()
        {

        }

        //显示新增按钮
        private bool showAdd = true;
        public bool ShowAdd
        {
            get { return showAdd; }
            set
            {
                showAdd = value;
                OnPropertyChanged();
            }
        }
        private bool showEdit = true;
        //显示修改按钮
        public bool ShowEdit
        {
            get { return showEdit; }
            set
            {
                showEdit = value;
                OnPropertyChanged();
            }
        }
        private bool showDelete = true;
        //显示删除按钮
        public bool ShowDelete
        {
            get { return showDelete; }
            set
            {
                showDelete = value;
                OnPropertyChanged();
            }
        }
        private bool showRecover = true;
        //显示恢复按钮
        public bool ShowRecover
        {
            get { return showRecover; }
            set
            {
                showRecover = value;
                OnPropertyChanged();
            }
        }
        private bool showRemove = true;
        //显示移除按钮
        public bool ShowRemove
        {
            get { return showRemove; }
            set
            {
                showRemove = value;
                OnPropertyChanged();
            }
        }
        private bool showClose = true;
        //显示关闭按钮
        public bool ShowClose
        {
            get { return showClose; }
            set
            {
                showClose = value;
                OnPropertyChanged();
            }
        }
        private bool showInfo= true;
        //显示详情按钮
        public bool ShowInfo
        {
            get { return showInfo; }
            set
            {
                showInfo = value;
                OnPropertyChanged();
            }
        }
        private bool showFind = false;
        //显示查询按钮
        public bool ShowFind
        {
            get { return showFind; }
            set
            {
                showFind = value;
                OnPropertyChanged();
            }
        }
        private bool showAllRequestList = false;
        //显示所有客户需求按钮
        public bool ShowAllRequestList
        {
            get { return showAllRequestList; }
            set
            {
                showAllRequestList = value;
                OnPropertyChanged();
            }
        }
        private bool showCustRequestList = false;
        //显示客户意向需求按钮
        public bool ShowCustRequestList
        {
            get { return showCustRequestList; }
            set
            {
                showCustRequestList = value;
                OnPropertyChanged();
            }
        }
        private bool showAllCustFULog = false;
        //显示所有客户日志按钮
        public bool ShowAllCustFULog
        {
            get { return showAllCustFULog; }
            set
            {
                showAllCustFULog = value;
                OnPropertyChanged();
            }
        }
        private bool showCustFULog = false;
        //显示客户跟进日志按钮
        public bool ShowCustFULog
        {
            get { return showCustFULog; }
            set
            {
                showCustFULog = value;
                OnPropertyChanged();
            }
        }
        private bool showRight = false;
        //显示权限分配按钮
        public bool ShowRight
        {
            get { return showRight; }
            set
            {
                showRight = value;
                OnPropertyChanged();
            }
        }
        private bool showImport = false;
        //显示导入按钮
        public bool ShowImport
        {
            get { return showImport; }
            set
            {
                showImport = value;
                OnPropertyChanged();
            }
        }
        private bool showPublish = false;
        //显示发布按钮
        public bool ShowPublish
        {
            get { return showPublish; }
            set
            {
                showPublish = value;
                OnPropertyChanged();
            }
        }
        private bool showUnPublish = false;
        //显示取消发布
        public bool ShowUnPublish
        {
            get { return showUnPublish; }
            set
            {
                showUnPublish = value;
                OnPropertyChanged();
            }
        }

        //新增命令
        private RelayCommand addCommand;
        public RelayCommand AddCommand {
            get { return addCommand; }
            set
            {
                addCommand = value;
                OnPropertyChanged();
            }
        }
        //修改命令
        private RelayCommand editCommand;
        public RelayCommand EditCommand 
        {
            get { return editCommand; }
            set
            {
                editCommand = value;
                OnPropertyChanged();
            }
        }
        //删除命令
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
            set
            {
                deleteCommand = value;
                OnPropertyChanged();
            }
        }
        //恢复命令
        private RelayCommand recoverCommand;
        public RelayCommand RecoverCommand
        {
            get { return recoverCommand; }
            set
            {
                recoverCommand = value;
                OnPropertyChanged();
            }
        }
        //移除命令
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get { return removeCommand; }
            set
            {
                removeCommand = value;
                OnPropertyChanged();
            }
        }
        //查询命令
        private RelayCommand findCommand;
        public RelayCommand FindCommand
        {
            get { return findCommand; }
            set
            {
                findCommand = value;
                OnPropertyChanged();
                                
            }
        }
        //查看命令
        private RelayCommand infoCommand;
        public RelayCommand InfoCommand
        {
            get { return infoCommand; }
            set
            {
                infoCommand = value;
                OnPropertyChanged();
            }
        }
        //权限分配命令
        private RelayCommand rightCommand;
        public RelayCommand RightCommand
        {
            get { return rightCommand; }
            set
            {
                rightCommand = value;
                OnPropertyChanged();
            }
        }
        //所有客户需求命令
        private RelayCommand allRequestListCommand;
        public RelayCommand AllRequestListCommand
        {
            get { return allRequestListCommand; }
            set
            {
                allRequestListCommand = value;
                OnPropertyChanged();
            }
        }
        //客户意向需求命令
        private RelayCommand custRequestListCommand;
        public RelayCommand CustRequestListCommand
        {
            get { return custRequestListCommand; }
            set
            {
                custRequestListCommand = value;
                OnPropertyChanged();
            }
        }
        //所有客户日志命令
        private RelayCommand custAllFULogCommand;
        public RelayCommand CustAllFULogCommand
        {
            get { return custAllFULogCommand; }
            set
            {
                custAllFULogCommand = value;
                OnPropertyChanged();
            }
        }
        //客户跟进日志命令
        private RelayCommand custFULogCommand;
        public RelayCommand CustFULogCommand
        {
            get { return custFULogCommand; }
            set
            {
                custFULogCommand = value;
                OnPropertyChanged();
            }
        }
       
        //导入数据命令
        private RelayCommand importCommand;
        public RelayCommand ImportCommand
        {
            get { return importCommand; }
            set
            {
                importCommand = value;
                OnPropertyChanged();
            }
        }
        private RelayCommand publishCommand;
        public RelayCommand PublishCommand
        {
            get { return publishCommand; }
            set
            {
                publishCommand = value;
                OnPropertyChanged();
            }
        }
        private RelayCommand unPublishCommand;
        public RelayCommand UnPublishCommand
        {
            get { return unPublishCommand; }
            set
            {
                unPublishCommand = value;
                OnPropertyChanged();
            }
        }

        //新增命令
        private RelayCommand closeCommand;
        public RelayCommand CloseCommand
        {
            get { return closeCommand; }
            set
            {
                closeCommand = value;
                OnPropertyChanged();
            }
        }
    }
}
