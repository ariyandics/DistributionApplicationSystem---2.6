USE [DEV_DC]
GO
/****** Object:  StoredProcedure [dbo].[spPrintsumaryAnggaranKAS]    Script Date: 24/09/2019 23.26.00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spPrintsumaryAnggaranKAS] @statusProsses as varchar(20), @date1 date, @date2 date
as
begin
	declare @iddc int
	select @iddc =iddc from mstdc where statusData =1

	if @statusProsses = 'NonRRAK'
		begin
		Select a.NomerNonRRAK,a.KodeToko,b.namaToko,convert(date,a.TglCreate) as TglCreate,convert(date,a.TglApproveToko) as TglApproveToko,convert(date, a.TglApproveWADS) as TglApproveWADS ,a.TotRealToko,a.TotRealWADS,a.TotNilaiSelisih from TblNonRRAKHeader a
		inner join Msttoko b on a.KodeToko =b.KodeToko 
		where convert(date,a.TglCreate) between @date1 and @date2  order by a.TglCreate
		end
	if @statusProsses = 'NonRRAKDetail'
		begin
		Select convert(date,c.TglCreate) as TglCreate,a.KodeToko,b.namaToko, a.NomerNonRRAK,a.KodeCOA,a.NamaCOA,a.NilaiRealToko,a.NilaiRealWADS,a.NilaiSelisih,a.Keterangan from TblNonRRAKDetail a
		inner join Msttoko b on a.KodeToko =b.KodeToko 
		inner join TblNonRRAKHeader c on c.KodeToko =a.KodeToko and c.NomerNonRRAK=a.NomerNonRRAK
		where convert(date,c.TglCreate) between @date1 and @date2 order by c.TglCreate
		end
	
	if @statusProsses = 'RRAKRealisasi'
		begin
		SELECT a.NomerRRAK,a.JenisRRAK,a.KodeToko,b.namaToko,convert(date,a.TglCreate) as TglCreate,convert(date,a.TglApproveEstimasi) as TglApproveEstimasi,convert(date,a.TglApproveRealisasi) as TglApproveRealisasi,a.TotEstimasi,a.TotRealisasi FROM TblRRAKHeader a
		inner join Msttoko b on a.KodeToko =b.KodeToko 
		where convert(date,a.TglApproveRealisasi) between @date1 and @date2 order by  a.TglApproveRealisasi
		end

	if @statusProsses = 'RRAKEstimasi'
		begin
		SELECT a.NomerRRAK,a.JenisRRAK,a.KodeToko,b.namaToko,convert(date,a.TglCreate) as TglCreate,convert(date,a.TglApproveEstimasi) as TglApproveEstimasi,convert(date,a.TglApproveRealisasi) as TglApproveRealisasi,a.TotEstimasi,a.TotRealisasi FROM TblRRAKHeader a
		inner join Msttoko b on a.KodeToko =b.KodeToko 
		where convert(date,a.TglApproveEstimasi) between @date1 and @date2 order by  a.TglApproveEstimasi
		end
	end