CREATE TABLE FUNCIONARIO (
	FuncCodigo INT IDENTITY NOT NULL,
	FuncNome VARCHAR(200) NOT NULL,
	CPF VARCHAR(14) UNIQUE CHECK (LEN(CPF) = 14) NOT NULL,
	PRIMARY KEY (FuncCodigo)
);

CREATE TABLE CATEGORIA(
	CtgaCodigo INT IDENTITY NOT NULL,
	CtgaDescricao VARCHAR(50) NOT NULL,
	PRIMARY KEY (CtgaCodigo)
);

CREATE TABLE VEICULO (
	VcoCodigo INT IDENTITY NOT NULL,
	VcoPlaca VARCHAR(8) UNIQUE CHECK (LEN(VcoPlaca) = 8) NOT NULL,
	VcoFrota VARCHAR(50) UNIQUE NOT NULL,
	VcoAnoModelo INT NOT NULL,
	VcoAnoFabricacao INT CHECK (VcoAnoFabricacao <= YEAR(GETDATE())) NOT NULL,
	VcoDataAquisicao DATETIME CHECK (VcoDataAquisicao <= GETDATE()) NOT NULL,
	VcoCodFuncResponsavel INT NOT NULL, 
	VcoCodCategoria INT NOT NULL,
	PRIMARY KEY (VcoCodigo),
	CONSTRAINT FK_FuncionarioVeiculo FOREIGN KEY (VcoCodFuncResponsavel)
	REFERENCES FUNCIONARIO(FuncCodigo),
	CONSTRAINT FK_CategoriaVeiculo FOREIGN KEY (VcoCodCategoria)
	REFERENCES CATEGORIA(CtgaCodigo)
);

--Views

CREATE VIEW VW_VEICULO
AS
SELECT V.VcoCodigo, V.VcoPlaca, V.VcoFrota, V.VcoAnoModelo, V.VcoAnoFabricacao,
V.VcoDataAquisicao, V.VcoCodFuncResponsavel, V.VcoCodCategoria, C.CtgaDescricao, F.FuncCodigo, 
F.FuncNome FROM VEICULO AS V
INNER JOIN CATEGORIA C ON C.CtgaCodigo = V.VcoCodCategoria
INNER JOIN FUNCIONARIO F ON F.FuncCodigo = V.VcoCodFuncResponsavel


