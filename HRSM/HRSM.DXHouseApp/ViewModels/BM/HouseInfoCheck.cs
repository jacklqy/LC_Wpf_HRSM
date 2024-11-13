using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HRSM.DXHouseApp.ViewModels.BM
{
        /// <summary>
        /// 房屋列表中的实体模型
        /// </summary>
       public  class HouseInfoCheck:ViewModelBase
        {
                private bool isCheck = false;
                public bool IsCheck
                {
                        get { return isCheck; }
                        set
                        {
                                isCheck = value;
                                OnPropertyChanged();
                        }
                }

                public bool IsPublish
                {
                        get { return viewhouseInfo.IsPublish; }
                        set
                        {
                                viewhouseInfo.IsPublish = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 是否显示交易按钮
                /// </summary>
                private Visibility isTradeVisibility = Visibility.Hidden;
                public Visibility IsTradeVisibility
                {
                        get
                        {
                                isTradeVisibility = (IsPublish&&(viewhouseInfo.HouseState=="未出租" || viewhouseInfo.HouseState == "未出售") )? Visibility.Visible : Visibility.Hidden;
                                return isTradeVisibility;
                        }
                        set
                        {
                                isTradeVisibility = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                /// 房屋信息
                /// </summary>
                private ViewHouseInfoModel viewhouseInfo;
                public ViewHouseInfoModel ViewHouseInfo
                {
                        get { return viewhouseInfo; }
                        set { viewhouseInfo = value;
                                OnPropertyChanged();
                        }
                }
        }
}
