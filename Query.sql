SELECT cap.Numero, p.Nome, cap.DataVencimento, cp.DataPagamento, cap.Valor, 
CASE cp.Numero 
	WHEN cap.Numero THEN 'Paga' 
	ELSE 'Não Paga' 
END Situacao
FROM ContasAPagar cap
LEFT JOIN ContasPagas cp ON cp.Numero = cap.Numero
INNER JOIN Pessoas p ON p.Codigo = cap.CodigoFornecedor
ORDER BY Situacao DESC