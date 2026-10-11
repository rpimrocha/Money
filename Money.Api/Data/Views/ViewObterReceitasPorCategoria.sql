CREATE OR ALTER VIEW [ViewObterReceitasPorCategoria] AS
	SELECT 
		[Transacoes].CodigoUsuario,
		[Categorias].Titulo AS [Categoria],
		YEAR([Transacoes].DataPagamento) AS [Ano],
		SUM([Transacoes].Valor) AS [Valor]
	FROM
		[Transacoes] 
		INNER JOIN [Categorias] ON [Transacoes].CodigoCategoria = [Categorias].Codigo
	WHERE
		[Transacoes].DataPagamento >= DATEADD(MONTH, -11, CAST(GETDATE() AS DATE))
		AND [Transacoes].Tipo = 1
	GROUP BY
		[Transacoes].CodigoUsuario,
		[Categorias].Titulo,
		YEAR([Transacoes].DataPagamento)