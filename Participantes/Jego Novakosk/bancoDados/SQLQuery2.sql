use crm


-- OPERAAÇÂO AND
SELECT a.primeiro_nome,
	   a.ultimo_nome,
	   a.nascimento,
	   a.sexo,
	   a.etnia
FROM cliente a
WHERE sexo = 'female'
AND etnia = 'Eskimo';

--OPERADOR BETWEEN

SELECT a.primeiro_nome,
	   a.ultimo_nome,
	   a.nascimento
FROM cliente a
WHERE a.sexo = 'female'
AND a.nascimento BETWEEN '1980-01-01' AND '1990-12-31'