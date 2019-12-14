USE [DEV_DC]
GO
/****** Object:  StoredProcedure [dbo].[spFind]    Script Date: 24/09/2019 23.25.06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

			-- ===================================================================
			-- Author		:By Fikri by Generator Script
			-- Create date	: May 31 2017 11:34AM
			-- Description	: All about DML in LpbSupplierDetail table
			-- ===================================================================
			
			
			ALTER procedure [dbo].[spFind]( @NamaForm varchar(50),@param2 varchar(50),@param3 varchar(50))
			as
			begin
			set transaction isolation level read committed ;
				if @NamaForm ='NomorPORCV'
					begin
						select a.*,b.namasupplier from (
							select nomorPo ,idsupplier,tglPo ,DATEADD(day, exttime, tglexpiredpo) as expinew,partialpo from podcheader 
							where  statusdata in (1,2)  and  DATEADD(day, exttime, tglexpiredpo) > convert(date,getdate()) and partialpo =1 
							union
							select nomorPo ,idsupplier,tglPo ,tglexpiredpo as expinew,partialpo from podcheader 
							where  statusdata in (1)  and tglexpiredpo  > convert(date,getdate()) and partialpo =0) a
							inner join mstsupplier b on a.idsupplier=b.idsupplier and b.namasupplier like @param2 
							where a.nomorPo not in (select a.nomorPo from podcheader a 
											  inner join ( select nomorPo,SUM(totalQtyPcs ) as qtyin from LpbSupplierHeader where statusData =1
											  group by nomorPo ) b on a.nomorPo =b.nomorPo 
											  where a.totalQty -b.qtyin =0 )
					end
				else
				if @NamaForm ='NomorLPB'
					begin
						
						select nomorLpb  ,namaSupplier ,convert(date,tglApprove ) as tglterima from LpbSupplierHeader a 
						inner join (select idsupplier,nomorPo  from PoDcHeader ) b on a.nomorPo =b.nomorPo 	
						inner join MstSupplier c on c.idSupplier =b.idSupplier 
						 where namasupplier like @param2 or nomorLpb like @param2

					end
				else
				if @NamaForm ='NoMutasiIn'
					begin
						select Nomutasiin,b.namaDc ,convert(date,tglapprove) as tglapprove from Mutasidcheaderin a
						inner join MstDC b on a.iddcpengirim =b.idDc 
						where b.namaDc  like @param2 or Nomutasiin like @param3

					end
				else
				
				if @NamaForm ='POManual'
					begin
						select KodeSupplier,NamaSupplier,namaSingkatSupplier from mstsupplier where idkategorisupplier <> 1 and statusData =1 and  namasupplier like @param2 
					end
				else	
				if @NamaForm ='SuppBKL'
					begin
						select KodeSupplier,NamaSupplier,namaSingkatSupplier from mstsupplier where idkategorisupplier in (1,3) and  namasupplier like @param2
					end
				else
				
				if @NamaForm ='Password'
					begin
						
						select * from MstUser 
						where namaUser in(
						select nama  from MstDcPenanggungJawab a
						inner join ( select idkaryawan,b.nama  from TblKaryawan  a
						inner join MstKaryawan b on a.nomorIdenTitas  =b.nomorIdenTitas ) b on a.idKaryawan =b.idKaryawan )
						and idUser =@param2 

					end
				else
				if @NamaForm ='NoRRAKE'
					begin
						select * from TblRRAKHeader where KodeToko = @param2 and StatusEstimasi  > 0 
					end
				else
				if @NamaForm ='NoRRAKR'
					begin
						select * from TblRRAKHeader where KodeToko = @param2 and StatusRealisasi   > 0 
					end
				else
				if @NamaForm ='NoKasBonE'
					begin
						select * from TblRRAKCashBondHeader where KodeToko = @param2 and StatusEstimasiCashBond >0
						
					end	
				else
				if @NamaForm ='NoKasBonR'
					begin
						select * from TblRRAKCashBondHeader where KodeToko = @param2 and StatusRealisasiCashBond  >0
						
					end	
				else
				if @NamaForm ='NoNonRRAK'
					begin
						select * from TblNonRRAKHeader where KodeToko = @param2 and StatusRealisasi  >0
						
					end	
				else
				if @NamaForm ='NoPL'
					begin
						Select a.nomorPicking,a.tglPicking ,b.kodetoko,b.namatoko,a.nomorpb from PickingHeader a 
						inner join mstToko b on a.kodetoko=b.kodetoko 
						where a.statusdata=1 and b.namatoko like @param2 
						and not  exists (select top 1* from TblTOTmp c where a.kodeToko =c.kodeToko and a.nomorPB =c.nomorPB and a.nomorPicking =c.nomorPicking )
					    order by tglPicking  desc
						
					end	
				else
				if @NamaForm ='NoPLStart'
					begin
						select * from TblTOTmp 
					    where kodeToko =@param2 and nomorPicking =@param3
					end	
				else
				if @NamaForm ='JwkBkl'
					begin
						Select kodetoko,namatoko,singkatantoko from msttoko 
						where kodetoko not in ( select kodetoko from JwkTOkoKeSupplier where idSUpplier =@param2 )		
						and namaToko like @param3 
					end	
				else
				if @NamaForm ='NoMutasiOut'
					begin
						select a.tglcreate,[NoMutasi],b.kodeDc, b.namaDc ,
						case a.statusdata when 1 then 'Approve' 
						when 2 then 'Receive'
						else 'Draft' end as statusdata
						from [MutasiDCHeaderOut] a
						inner join mstdc b on a.[idDcPenerima] = b.idDc 
						where a.[NoMutasi] like @param2
					end	
				else
				if @NamaForm ='NoMutasiDCOut'
					begin
						select nomutasi,tglapprove from [MutasiDCHeaderOut] 
						where iddcpengirim=@param2 and statusdata=1 and nomutasi like @param3
					end	
				else
				if @NamaForm ='MasterDC'
					begin
						Select kodedc,namaDc from MstDC  
						where statusData =0 and namadc like @param2 
					end	
				else
				if @NamaForm ='GetDC'
					begin
						Select iddc,kodedc,namaDc from MstDC  
						where statusData =0 and kodedc=@param2
					end	
				else
				if @NamaForm ='GetProduk'
					begin
						select idproduk,kodeproduk,barcode,namapanjang,namapendek,kodetag from mstproduk
						where kodeproduk like @param2 or barcode =@param2
					end		
				else
				if @NamaForm ='NoTObyPB'
					begin
						Select a.nomorto,convert(date,a.tglto) tglto,a.kodetoko,b.namatoko,
						case when a.statusData =1 then 'Approve' 
						when a.statusData =0 then 'Draft'
						else 'Receive' end as keterangan
						from ToKeTokoHeader a 
						inner join mstToko b on a.kodetoko=b.kodetoko where namatoko like @param2 order by tglto desc
					end		
				else
				if @NamaForm ='NoTOManual'
					begin
						Select a.nomorto,convert(date,a.tglto)tglto ,a.kodetoko,b.namatoko,
						case when a.statusData =1 then 'Approve' 
						when a.statusData =0 then 'Draft'
						else 'Receive' end as keterangan
						 from ToKeTokoHeaderManual a 
						inner join mstToko b on a.kodetoko=b.kodetoko where namatoko like @param2 or nomorTo like @param2 order by tglto desc
					end		
				else
								
				if @NamaForm ='GetAllProduk'
					begin
						select idproduk,kodeproduk,barcode,namapanjang,namapendek,kodetag from mstproduk
						where kodeproduk like @param2 or namapanjang like @param2
					end		
				else
								
				if @NamaForm ='MasterToko'
					begin
						Select kodetoko,namatoko,singkatantoko from msttoko where namatoko like @param2 and statusData =1
					end		
				else
				if @NamaForm ='GetNoAdj'
					begin
						select nomorSoAdjusment,tglSOAdjusment ,b.namaJenisStok ,case when a.statusData =0 then 'Draft' 
						when  a.statusData =1 then 'Approve' else 'Done'
						end as Keterangan
						from SoAdjusmentHeader a 
						inner join MstJenisStok b on a.idJenisStok =b.idJenisStok 
						where idDc = convert(int,@param3)
						order by nomorSoAdjusment desc
					end	
				else
				if @NamaForm ='GetReturS'
					begin
						select nomorRetur,b.kodeSupplier ,b.namaSupplier,
						case when a.statusData =1 then 'Approve' 
						else 'Draft' end as keterangan
						from ReturDcHeaderKeSupplier a
						inner join MstSupplier b on a.idSupplier =b.idSupplier 
						where b.namaSupplier like @param2
						order by nomorRetur desc
					end		
									
			end 
