USE [DEV_DC]
GO
/****** Object:  StoredProcedure [dbo].[spTblNonRRAK]    Script Date: 24/09/2019 23.24.06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

			
ALTER procedure [dbo].[spTblNonRRAK]( @statusProses varchar(20), @NomorNonRRAK bigint,@KodeToko bigint,@nilaibaru as bigint,@kodecoa varchar(10),@namacoa varchar(100))
			as
			begin
				set transaction isolation level read committed ; 
				declare @nilaiheader bigint
				declare @nilaiselsih bigint
				
			   if @statusProses = 'Getstatus'
			    begin
						select * from TblNonRRAKHeader
						where KodeToko =@KodeToko  and NomerNonRRAK =@NomorNonRRAK 
			    end

				if @statusProses = 'GetRealisasiawal'
					begin
						select a.KodeCOA ,a.NamaCOA,Keterangan ,a.NilaiRealToko from TblNonRRAKDetail a
						inner join TblNonRRAKHeader b on a.NomerNonRRAK =b.NomerNonRRAK and a.KodeToko =b.KodeToko 
						where a.KodeToko =@KodeToko  and a.NomerNonRRAK =@NomorNonRRAK 
				end

				if @statusProses = 'GetRealisasi'
					begin
					declare @totwads integer
					declare @stsreal integer
					
					select @totwads = TotRealWADS, @stsreal =  Statusrealisasi from TblNonRRAKHeader where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK
						if @totwads =0 and  @stsreal=2
							begin	
							select a.KodeCOA ,a.NamaCOA ,a.Keterangan,a.NilaiRealToko,a.NilaiRealToko,a.NilaiSelisih   from TblNonRRAKDetail a
							inner join TblNonRRAKHeader b on a.NomerNonRRAK =b.NomerNonRRAK and a.KodeToko =b.KodeToko 
							where a.KodeToko =@KodeToko  and a.NomerNonRRAK =@NomorNonRRAK 
							end
						else
							begin
							select a.KodeCOA ,a.NamaCOA ,a.Keterangan,a.NilaiRealToko,a.NilaiRealWADS,a.NilaiSelisih   from TblNonRRAKDetail a
							inner join TblNonRRAKHeader b on a.NomerNonRRAK =b.NomerNonRRAK and a.KodeToko =b.KodeToko 
							where a.KodeToko =@KodeToko  and a.NomerNonRRAK =@NomorNonRRAK 
						end
				end
				if @statusProses = 'EditData'
						begin
						select @nilaibaru
						if @nilaibaru >0
						begin
						update  TblNonRRAKDetail
						set NilaiRealWADS  =@nilaibaru 
						where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK and KodeCOA =@kodecoa and NamaCOA =@namacoa 
						update TblNonRRAKDetail
						set NilaiSelisih=(NilaiRealToko-NilaiRealWADS)
						where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK and KodeCOA =@kodecoa and NamaCOA =@namacoa 

						
						select @nilaiheader =	SUM( NilaiRealWADS ) from TblNonRRAKDetail
						where KodeToko =@KodeToko and NomerNonRRAK =@NomorNonRRAK --and KodeCOA =@kodecoa and NamaCOA =@namacoa 
						select @nilaiselsih =	SUM( NilaiSelisih ) from TblNonRRAKDetail
						where KodeToko =@KodeToko and NomerNonRRAK =@NomorNonRRAK --and KodeCOA =@kodecoa and NamaCOA =@namacoa 
						update TblNonRRAKHeader
						set TotRealWADS  =@nilaiheader ,TotNilaiSelisih=@nilaiselsih
						where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK 


						--status save (1)
						update TblNonRRAKHeader
						set StatusData  =1  where KodeToko =@KodeToko  and NomerNonRRAK =@NomorNonRRAK 
						end 
			    end
						if @statusProses = 'nilaitidakedit'
						begin
						select @nilaibaru
						if @nilaibaru =0
						begin
						update  TblNonRRAKDetail
						set NilaiRealWADS  =@nilaibaru 
						where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK and KodeCOA =@kodecoa and NamaCOA =@namacoa 
						update TblNonRRAKDetail
						set NilaiSelisih=(NilaiRealToko-NilaiRealWADS)
						where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK and KodeCOA =@kodecoa and NamaCOA =@namacoa 

						
						select @nilaiheader =	SUM( NilaiRealWADS ) from TblNonRRAKDetail
						where KodeToko =@KodeToko and NomerNonRRAK =@NomorNonRRAK --and KodeCOA =@kodecoa and NamaCOA =@namacoa 
						select @nilaiselsih =	SUM( NilaiSelisih ) from TblNonRRAKDetail
						where KodeToko =@KodeToko and NomerNonRRAK =@NomorNonRRAK --and KodeCOA =@kodecoa and NamaCOA =@namacoa 
						update TblNonRRAKHeader
						set TotRealWADS  =@nilaiheader ,TotNilaiSelisih=@nilaiselsih
						where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK 


						--status save (1)
						update TblNonRRAKHeader
						set StatusData  =1 ,TglApproveWADS =GETDATE() where KodeToko =@KodeToko  and NomerNonRRAK =@NomorNonRRAK
						end
			    end
				
					if @statusProses = 'Approve'
						begin
							select @nilaibaru =	SUM( NilaiRealWADS ) from TblNonRRAKDetail where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK
							if @nilaibaru =0
							begin
								update  TblNonRRAKDetail
								set NilaiRealWADS  =NilaiRealToko 
								where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK
								-- and KodeCOA =@kodecoa and NamaCOA =@namacoa 
							end
						
					
								--select @nilaiselsih =	SUM( NilaiSelisi ) from TblNonRRAKDetail
								--where KodeToko =@KodeToko and NomerNonRRAK =@NomorNonRRAK
								select @nilaiheader =	SUM( NilaiRealWADS ) from TblNonRRAKDetail
								where KodeToko =@KodeToko and NomerNonRRAK =@NomorNonRRAK
								update TblNonRRAKHeader
								set TotRealWADS  =@nilaiheader ,TotNilaiSelisih=@nilaiselsih
								where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK 
						
								update TblNonRRAKDetail 
								set NilaiSelisih=(NilaiRealToko-NilaiRealWADS)
								where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK
								update TblNonRRAKHeader
								set TotNilaiSelisih=(TotRealToko-TotRealWADS)
								where KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK

								declare @GetTglBikin date
								set @GetTglBikin = (select tglcreate from TblNonRRAKHeader where KodeToko=@KodeToko and NomerNonRRAK=@NomorNonRRAK)
								if month(@GetTglBikin)<month(getdate())
									begin
										update TblNonRRAKHeader
										set StatusRealisasi  =4 ,TglApproveWADS =GETDATE() where KodeToko =@KodeToko  and NomerNonRRAK =@NomorNonRRAK  
									end
								else
									begin
										update TblNonRRAKHeader
										set StatusRealisasi  =3 ,TglApproveWADS =GETDATE() where KodeToko =@KodeToko  and NomerNonRRAK =@NomorNonRRAK
									end
						  

							end

						

					if @statusProses = 'Print'
						Select a.KodeCOA,a.NamaCOA,a.Keterangan,a.NilaiRealToko,a.NilaiRealWADS,a.NilaiSelisih,convert(date,b.TglCreate) as TglCreate from TblNonRRAKDetail a
						inner join TblNonRRAKHeader b on a.NomerNonRRAK =b.NomerNonRRAK and a.KodeToko =b.KodeToko 
						 where a.KodeToko =@KodeToko and  a.NomerNonRRAK =@NomorNonRRAK
					end
		
					if @statusProses = 'BulanAktif'
					 begin
						select convert(date,TglCreate) as TglCreate from TblNonRRAKHeader where  KodeToko =@KodeToko and  NomerNonRRAK =@NomorNonRRAK
					 end
					 