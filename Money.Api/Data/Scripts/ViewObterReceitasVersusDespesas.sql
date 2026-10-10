CREATE OR ALTER VIEW [ViewObterReceitasVersusDespesas] AS
	SELECT 
		[Transacoes].CodigoUsuario,
		MONTH([Transacoes].DataPagamento) AS Mes,
		YEAR([Transacoes].DataPagamento) AS Ano,
		SUM(CASE WHEN [Transacoes].Tipo = 1 THEN [Transacoes].Valor ELSE 0 END) AS Receitas,
		SUM(CASE WHEN [Transacoes].Tipo = 2 THEN [Transacoes].Valor ELSE 0 END) AS Despesas
	FROM
		[Transacoes] 
	WHERE
		[Transacoes].DataPagamento >= DATEADD(MONTH, -11, CAST(GETDATE() AS DATE))
		AND [Transacoes].Tipo = 1
	GROUP BY
		[Transacoes].CodigoUsuario,
		MONTH([Transacoes].DataPagamento),
		YEAR([Transacoes].DataPagamento)