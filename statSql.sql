--���������ͳ�Ʒ�����
create view ViewHouseCountSatistics
as
select TotalCount=( select count(1) from HouseInfos where IsDeleted=0 ),
PublishedCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1),
UnPublishedCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=0),
TRentCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='����'),
HasRentCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='����' and HouseState='�ѳ���'),
UnRentCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='����' and HouseState='δ����'),
TSaleCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='����'),
HasSaleCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='����' and HouseState='�ѳ���'),
UnSaleCount=(select count(1)  from HouseInfos where IsDeleted=0 
and IsPublish=1 and RentSale='����' and HouseState='δ����')

--������Աͳ��
create view ViewSaleHouseStatistics
as
with temp as
(
select DealUser,UserFName,HouseId,RentSale from HouseTradeInfos ht
inner join UserInfos u on u.UserName=ht.DealUser
)
select DealUser,UserFName, TotalCount=( select count(1) from temp where a.DealUser=DealUser),
RentCount=( select count(1) from temp where a.DealUser=DealUser and RentSale='����'),
SaleCount=( select count(1) from temp where a.DealUser=DealUser and RentSale='����')
 from temp a
 group by DealUser,UserFName

 select * from ViewSaleHouseStatistics;


 --��ʱ��ͳ��������
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
RentCount=( select count(1) from temp1 where a.DealUser=DealUser and RentSale='����'),
SaleCount=( select count(1) from temp1 where a.DealUser=DealUser and RentSale='����')
 from temp1 a
 group by DealUser,UserFName
 )

 select * from [dbo].StatisticsSaleHouseByTime('��','2020-06-01 00:00:00','2020-06-10 23:59:59') 
 select * from [dbo].StatisticsSaleHouseByTime('','2020-06-09 23:59:59')
  select * from [dbo].StatisticsSaleHouseByTime('2020-06-09 00:00:00','')
