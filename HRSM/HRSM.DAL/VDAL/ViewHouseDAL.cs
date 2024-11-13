using HRSM.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRSM.DAL.VDAL
{
    public class ViewHouseDAL:BQuery<ViewHouseInfoModel>
    {
        /// <summary>
        /// 条件查询房屋信息列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="rentSaleName"></param>
        /// <param name="houseDirection"></param>
        /// <param name="houseLayout"></param>
        /// <param name="houseState"></param>
        /// <param name="isPublish"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public List<ViewHouseInfoModel> GetHouseList(string keywords, string rentSaleName, string houseDirection, string houseLayout, string houseState, int isPublish, int isDeleted)
        {
            string cols = "HouseId,HouseName,Building,HouseAddress,RentSale,HouseDirection,HouseLayout,OwnerId,OwnerName,HouseState,IsPublish";
            string strWhere = $"IsDeleted={isDeleted}";
            List<SqlParameter> listParas = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(keywords))
            {
                strWhere += " and (HouseName like @keywords or Building like @keywords or HouseAddress like @keywords or OwnerName like @keywords)";
                listParas.Add(new SqlParameter("@keywords", $"%{keywords}%"));
            }
            if (!string.IsNullOrEmpty(rentSaleName))
            {
                strWhere += " and RentSale=@rentSale";
                listParas.Add(new SqlParameter("@rentSale", rentSaleName));
            }
            if (!string.IsNullOrEmpty(houseDirection))
            {
                strWhere += " and HouseDirection=@houseDirection";
                listParas.Add(new SqlParameter("@houseDirection", houseDirection));
            }
            if (!string.IsNullOrEmpty(houseLayout))
            {
                strWhere += " and HouseLayout=@houseLayout";
                listParas.Add(new SqlParameter("@houseLayout", houseLayout));
            }
            if (!string.IsNullOrEmpty(houseState))
            {
                strWhere += " and HouseState=@houseState";
                listParas.Add(new SqlParameter("@houseState", houseState));
            }
            if (isPublish != -1)
                strWhere += $" and IsPublish={isPublish}";
            strWhere += $" and IsDeleted={isDeleted}";
            return GetRowsModelList(strWhere, cols, listParas.ToArray());
        }

        /// <summary>
        /// 获取指定的房屋信息
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        public ViewHouseInfoModel GetViewHouseInfo(int houseId)
        {
            string cols = "HouseId,HouseName,Building,HouseAddress,RentSale,HouseDirection,HouseLayout,OwnerId,OwnerName,HouseArea,HouseFloor,HousePrice,PriceUnit,IsPublish,HouseState,Remark,HousePic,OwnerPhone";
            return GetById(houseId, cols);
        }

        public List<ViewHouseInfoModel> GetShowHouseList(string houseName,string rentSale,string direction,string layout)
        {
            string cols = "HouseId,HouseName,RentSale,HouseDirection,HouseLayout,OwnerId,OwnerName,HousePic,HouseState";
            string strWhere = $"IsDeleted=0 and IsPublish=1";
            List<SqlParameter> listParas = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(houseName))
            {
                strWhere += " and HouseName like @houseName";
                listParas.Add(new SqlParameter("@houseName", $"%{houseName}%"));
            }
            if (!string.IsNullOrEmpty(rentSale))
            {
                strWhere += " and RentSale = @rentSale";
                listParas.Add(new SqlParameter("@rentSale", rentSale));
            }
            if (!string.IsNullOrEmpty(direction))
            {
                strWhere += " and HouseDirection = @direction";
                listParas.Add(new SqlParameter("@direction", direction));
            }
            if (!string.IsNullOrEmpty(layout))
            {
                strWhere += " and HouseLayout like @layout";
                listParas.Add(new SqlParameter("@layout", $"%{layout}%"));
            }
            return GetRowsModelList(strWhere, cols, listParas.ToArray());
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
            StatQueryWhereModel whereModel = SetStatQueryWhere(propName);
            string cols = "HouseId,HouseName,Building,HouseAddress,RentSale,HouseDirection,HouseLayout,OwnerId,OwnerName,HouseState";
            string strWhere = $"IsDeleted=0";
            List<SqlParameter> listParas = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(whereModel.RSName))
            {
                strWhere += " and RentSale=@rentSale";
                listParas.Add(new SqlParameter("@rentSale", whereModel.RSName));
            }
            if (!string.IsNullOrEmpty(whereModel.HouseState))
            {
                strWhere += " and HouseState=@houseState";
                listParas.Add(new SqlParameter("@houseState", whereModel.HouseState));
            }
            if (whereModel.IsPublish != -1)
                strWhere += $" and IsPublish={whereModel.IsPublish}";
            if (!string.IsNullOrEmpty(dealUser))
            {
                strWhere += " and HouseId in (select HouseId from HouseTradeInfos where DealUser=@dealUser and IsDeleted=0)";
                listParas.Add(new SqlParameter("@dealUser",dealUser));
            }
                
            return GetRowsModelList(strWhere, cols, listParas.ToArray());
        }

        private StatQueryWhereModel SetStatQueryWhere(string propName)
        {
            int isPublish = -1;
            string rsName = "", houseState = "";
            switch (propName)
            {
                case "PublishedCount":
                    isPublish = 1;
                    break;
                case "UnPublishedCount":
                    isPublish = 0;
                    break;
                case "TRentCount":
                    isPublish = 1;
                    rsName = "出租";
                    break;
                case "TSaleCount":
                    isPublish = 1;
                    rsName = "出售";
                    break;
                case "HasRentCount":
                case "RentCount":
                    isPublish = 1;
                    rsName = "出租";
                    houseState = "已出租";
                    break;
                case "UnRentCount":
                    isPublish = 1;
                    rsName = "出租";
                    houseState = "未出租";
                    break;
                case "HasSaleCount":
                case "SaleCount":
                    isPublish = 1;
                    rsName = "出售";
                    houseState = "已出售";
                    break;
                case "UnSaleCount":
                    isPublish = 1;
                    rsName = "出售";
                    houseState = "未出售";
                    break;
                case "TotalCount":
                    isPublish = 1;
                    break;

              
            }
            return new StatQueryWhereModel()
            {
                IsPublish = isPublish,
                RSName = rsName,
                HouseState = houseState
            };
        }
    }
}
