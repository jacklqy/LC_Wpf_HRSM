--按租售类别统计房屋数
create view ViewHouseCountSatistics
as
select TotalCount=( select count(1) from HouseInfos where IsDeleted=0 ),
PublishedCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1),
UnPublishedCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=0),
TRentCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='出租'),
HasRentCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='出租' and HouseState='已出租'),
UnRentCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='出租' and HouseState='未出租'),
TSaleCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='出售'),
HasSaleCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='出售' and HouseState='已出售'),
UnSaleCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='出售' and HouseState='未出售')

--按销售员统计
create view ViewSaleHouseStatistics
as
with temp as
(
select DealUser,UserFName,HouseId,RentSale from HouseTradeInfos ht
inner join UserInfos u on u.UserName=ht.DealUser
)
select DealUser,UserFName, TotalCount=( select count(1) from temp where a.DealUser=DealUser),
RentCount=( select count(1) from temp where a.DealUser=DealUser and RentSale='出租'),
SaleCount=( select count(1) from temp where a.DealUser=DealUser and RentSale='出售')
 from temp a
 group by DealUser,UserFName

 select * from ViewSaleHouseStatistics;


 --按时间统计销售量
 create function dbo.StatisticsSaleHouseByTime(@saleUser varchar(50),@startTime varchar(50),@endTime varchar(50))
 returns table
 as return(
with temp1 as
(
select DealUser,UserFName,HouseId,RentSale,TradeTime from HouseTradeInfos ht
inner join UserInfos u on u.UserName=ht.DealUser
where (@saleUser<>'' and UserFName like '%'+@saleUser+'%' or @saleUser='')  
and ((TradeTime between @startTime and @endTime and @startTime<>'' and @endTime<>'' ) or 
(TradeTime >=@startTime and @endTime='') or (TradeTime <=@endTime and @startTime=''))
)
select DealUser,UserFName,TotalCount=( select count(1) from temp1 where a.DealUser=DealUser),
RentCount=( select count(1) from temp1 where a.DealUser=DealUser and RentSale='出租'),
SaleCount=( select count(1) from temp1 where a.DealUser=DealUser and RentSale='出售')
 from temp1 a
 group by DealUser,UserFName
 )

 select * from [dbo].StatisticsSaleHouseByTime('李','2020-06-01 00:00:00','2020-06-10 23:59:59') 
 select * from [dbo].StatisticsSaleHouseByTime('','2020-06-09 23:59:59')
  select * from [dbo].StatisticsSaleHouseByTime('2020-06-09 00:00:00','')
