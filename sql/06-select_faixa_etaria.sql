SELECT
    CASE
        WHEN DATEDIFF(YEAR, U.DataNascimento, GETDATE()) <= 20 THEN 'Até 20 anos'
        WHEN DATEDIFF(YEAR, U.DataNascimento, GETDATE()) BETWEEN 21 AND 50 THEN 'De 21 a 50 anos'
        ELSE 'Acima de 50 anos'
    END AS FaixaEtaria,
    U.Nome,
    U.Sobrenome,
    U.Email
FROM
    Usuario U
INNER JOIN Escolaridade E ON U.IdEscolaridade = E.IdEscolaridade
WHERE
    E.IdEscolaridade = 4
ORDER BY U.DataNascimento