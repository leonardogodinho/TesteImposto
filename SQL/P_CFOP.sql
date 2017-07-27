CREATE PROCEDURE [dbo].[P_CFOP]	
AS
	SELECT nfi.Cfop CFOP,
		   sum(nfi.BaseIcms) ValorTotalBaseICMS,
		   sum(nfi.ValorIcms) ValorTotalICMS,
		   sum(nfi.BaseIpi) ValorTotalBaseIPI,
		   sum(nfi.ValorIpi) ValorTotalIPI
	FROM NotaFiscalItem nfi
	GROUP BY nfi.Cfop;
RETURN 0