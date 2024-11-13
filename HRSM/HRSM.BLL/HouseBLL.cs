using HRSM.Common;
using HRSM.DAL;
using HRSM.DAL.VDAL;
using HRSM.Models.DModels;
using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.BLL
{
        public class HouseBLL
        {
                private HouseDAL houseDAL = new HouseDAL();
                private ViewHouseDAL vhDAL = new ViewHouseDAL();
                private HouseTradeDAL htDAL = new HouseTradeDAL();
                private ViewHouseStatisticsDAL vhsatDAL = new ViewHouseStatisticsDAL();
                /// <summary>
                /// 添加房屋信息
                /// </summary>
                /// <param name="houseInfo"></param>
                /// <returns></returns>
                public bool AddHouseInfo(HouseInfoModel houseInfo)
                {
                        return houseDAL.AddHouseInfo(houseInfo);
                }

                /// <summary>
                /// 修改房屋信息
                /// </summary>
                /// <param name="houseInfo"></param>
                /// <returns></returns>
                public bool UpdateHouseInfo(HouseInfoModel houseInfo)
                {
                        return houseDAL.UpdateHouseInfo(houseInfo);
                }

                /// <summary>
                /// 导入房屋数据
                /// </summary>
                /// <param name="excelFile"></param>
                /// <param name="sheetName"></param>
                /// <param name="isFirstRowColumn"></param>
                /// <returns></returns>
                public int ImportHouseData(string excelFile, string sheetName, bool isFirstRowColumn)
                {
                        DataTable dt = ExcelHelper.ExcelToDataTable(excelFile, sheetName, isFirstRowColumn);
                        if (dt.Rows.Count > 0)
                        {
                                bool bl = houseDAL.AddHouseInfos(dt);
                                if (bl)
                                        return 1;
                                else
                                        return 0;
                        }
                        else
                                return -1;
                }

                #region 发布与取消发布
                /// <summary>
                /// 发布房屋信息
                /// </summary>
                /// <param name="houseIds"></param>
                /// <param name="loginUser"></param>
                /// <returns></returns>
                public bool PublishHouse(List<int> houseIds, string loginUser)
                {
                        return houseDAL.UpdateHousePublishState(houseIds, 1, loginUser);
                }

                /// <summary>
                /// 取消发布
                /// </summary>
                /// <param name="houseIds"></param>
                /// <returns></returns>
                public bool UnPublishHouse(List<int> houseIds)
                {
                        return houseDAL.UpdateHousePublishState(houseIds, 0, null);
                }
                #endregion

                #region 删除与恢复
                /// <summary>
                /// 删除房屋信息（假删除）
                /// </summary>
                /// <param name="houseId"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool LogicDelHouse(int houseId)
                {
                        return houseDAL.UpdateHouseInfoState(houseId, 0, 1);

                }

                /// <summary>
                /// 恢复房屋信息
                /// </summary>
                /// <param name="houseId"></param>
                /// <returns></returns>
                public bool RecoverHouse(int houseId)
                {
                        return houseDAL.UpdateHouseInfoState(houseId, 0, 0);
                }

                /// <summary>
                /// 删除房屋信息（真删除）
                /// </summary>
                /// <param name="houseId"></param>
                /// <returns></returns>
                public bool RemoveHouse(int houseId)
                {
                        return houseDAL.UpdateHouseInfoState(houseId, 1, 2);
                }

                /// <summary>
                /// 批量删除房屋信息（假删除）
                /// </summary>
                /// <param name="houseIds"></param>
                /// <param name="delType">0-假删除 1-真删除 </param>
                /// <returns></returns>
                public bool LogicDelHouseList(List<int> houseIds)
                {
                        return houseDAL.UpdateHousesState(houseIds, 0, 1);
                }

                /// <summary>
                /// 批量恢复房屋信息
                /// </summary>
                /// <param name="houseIds"></param>
                /// <returns></returns>
                public bool RecoverHouseList(List<int> houseIds)
                {
                        return houseDAL.UpdateHousesState(houseIds, 0, 0);
                }

                /// <summary>
                /// 批量删除房屋信息（真删除）
                /// </summary>
                /// <param name="houseIds"></param>
                /// <returns></returns>
                public bool RemoveHouseList(List<int> houseIds)
                {
                        return houseDAL.UpdateHousesState(houseIds, 1, 2);
                }


                #endregion

                #region 房屋信息查询
                /// <summary>
                /// 获取指定id的房屋信息
                /// </summary>
                /// <param name="houseId"></param>
                /// <returns></returns>
                public HouseInfoModel GetHouseInfo(int houseId)
                {
                        return houseDAL.GetHouseInfo(houseId);
                }

                public ViewHouseInfoModel GetViewHouseInfo(int houseId)
                {
                        return vhDAL.GetViewHouseInfo(houseId);
                }

                /// <summary>
                /// 判断房屋是否已存在
                /// </summary>
                /// <param name="houseName"></param>
                /// <returns></returns>
                public bool Exists(string houseName)
                {
                        return houseDAL.Exists(houseName);
                }

                /// <summary>
                /// 判断指定房屋是否已交易（出售或出租）
                /// </summary>
                /// <param name="houseId"></param>
                /// <returns></returns>
                public bool IsTradeHouse(int houseId)
                {
                        List<int> houseIds = new List<int>();
                        houseIds.Add(houseId);
                        return htDAL.GetTradeHouseCount(houseIds) > 0;
                }

                public bool IsTradeHouse(List<int> houseIds)
                {
                        return htDAL.GetTradeHouseCount(houseIds) > 0;
                }

                /// <summary>
                /// 判断指定的房屋是否已发布
                /// </summary>
                /// <param name="houseId"></param>
                /// <returns></returns>
                public bool IsPublishedHouse(int houseId)
                {
                        List<int> houseIds = new List<int>();
                        houseIds.Add(houseId);
                        return houseDAL.GetHousePublished(houseIds) > 0;
                }

                public bool IsPublishedHouse(List<int> houseIds)
                {
                        return houseDAL.GetHousePublished(houseIds) > 0;
                }

                /// <summary>
                ///  获取所有房屋列表（未删除的），用于绑定下拉框
                /// </summary>
                /// <returns></returns>
                public List<HouseInfoModel> GetAllHouses()
                {
                        return houseDAL.GetAllHouses();
                }

                /// <summary>
                /// 条件查询房屋信息列表
                /// </summary>
                /// <param name="keywords"></param>
                /// <param name="ownerType"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<ViewHouseInfoModel> GetHouseList(string keywords, string rentSaleName, string houseDirection, string houseLayout, string houseState, int isPublish, int isDeleted)
                {
                        return vhDAL.GetHouseList(keywords, rentSaleName, houseDirection, houseLayout, houseState, isPublish, isDeleted);
                }

                /// <summary>
                /// 获取房屋列表（已发布房屋）
                /// </summary>
                /// <param name="houseName"></param>
                /// <param name="rentSale"></param>
                /// <param name="direction"></param>
                /// <param name="layout"></param>
                /// <returns></returns>
                public List<ViewHouseInfoModel> GetShowHouseList(string houseName, string rentSale, string direction, string layout)
                {
                        //ObservableCollection<ViewHouseInfoModel> list1 = new ObservableCollection<ViewHouseInfoModel>();
                        List<ViewHouseInfoModel> list = vhDAL.GetShowHouseList(houseName, rentSale, direction, layout);
                        foreach (ViewHouseInfoModel model in list)
                        {
                                if (!string.IsNullOrEmpty(model.HousePic))
                                        model.HousePic = "../" + model.HousePic;
                                else
                                        model.HousePic = "../imgs/house.jpg";

                        }
                        return list;
                }

                /// <summary>
                /// 获取房屋统计信息
                /// </summary>
                /// <returns></returns>
                public ViewHouseCountSatisticsModel GetHouseStatistics()
                {
                        return vhsatDAL.GetHouseStatistics();
                }

                /// <summary>
                /// 获取统计相关的房屋明细列表
                /// </summary>
                /// <param name="isPublish"></param>
                /// <param name="rsName"></param>
                /// <param name="houseState"></param>
                /// <returns></returns>
                public List<ViewHouseInfoModel> GetStatHouseList(string propName, string dealUser)
                {
                        return vhDAL.GetStatHouseList(propName, dealUser);
                }

                #endregion
        }
}
