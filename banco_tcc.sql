DROP DATABASE IF EXISTS tomoe_sushi;

CREATE DATABASE IF NOT EXISTS tomoe_sushi;

USE tomoe_sushi;

CREATE TABLE IF NOT EXISTS cliente (
	id_cli INT PRIMARY KEY AUTO_INCREMENT,
    nome_cli VARCHAR(100) NOT NULL,
    email_cli VARCHAR(50) NOT NULL,
    user_cli VARCHAR(20) NOT NULL UNIQUE,
    senha_cli VARCHAR(10) NOT NULL,
    tel_cli VARCHAR(20) NOT NULL,
    cep_cli VARCHAR(50),
    logradouro_cli VARCHAR(100) ,
    num_cli INT,
    complemento_cli VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS mesa (
	id_mesa INT PRIMARY KEY AUTO_INCREMENT,
    num_mesa INT NOT NULL UNIQUE,
    num_assentos INT NOT NULL,
    status_mesa VARCHAR(20) NOT NULL
);

CREATE TABLE IF NOT EXISTS produto (
	id_prod INT PRIMARY KEY AUTO_INCREMENT,
    nome_prod VARCHAR(100) NOT NULL UNIQUE,
    desc_prod VARCHAR(400) NOT NULL,
    preco_prod DECIMAL(10,2) NOT NULL,
    categoria_prod VARCHAR(100) NOT NULL,
    status_prod VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS pedido (
	id_pedido INT PRIMARY KEY AUTO_INCREMENT,
    data_hora_pedido DATETIME NOT NULL,
    status_pedido VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS funcionario (
	id_func INT PRIMARY KEY AUTO_INCREMENT,
    nome_func VARCHAR(100) NOT NULL,
    email_func VARCHAR(50) NOT NULL,
    user_func VARCHAR(20) NOT NULL UNIQUE,
    senha_func VARCHAR(10) NOT NULL,
    tel_func VARCHAR(20) NOT NULL,
    nivel_acesso INT NOT NULL
);

CREATE TABLE IF NOT EXISTS reserva (
	id_reserva INT PRIMARY KEY AUTO_INCREMENT,
    num_pessoas INT NOT NULL,
    data_hora_reserva datetime NOT NULL,
	status_reserva VARCHAR(50) NOT NULL,
    id_cli INT NOT NULL,
    id_mesa INT NOT NULL,
    FOREIGN KEY(id_cli) REFERENCES cliente (id_cli),
    FOREIGN KEY(id_mesa) REFERENCES mesa (id_mesa)
    ON DELETE CASCADE 
	ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS carrinho (
	id_carrinho INT PRIMARY KEY AUTO_INCREMENT,
    cep_carrinho VARCHAR(50) NOT NULL,
    logradouro_carrinho VARCHAR(100) NOT NULL,
    num_carrinho INT NOT NULL,
    complemento_carrinho VARCHAR(50),
    id_pedido INT NOT NULL,
    id_cli INT NOT NULL,
    FOREIGN KEY(id_cli) REFERENCES cliente (id_cli),
    FOREIGN KEY(id_pedido) REFERENCES pedido (id_pedido)
    ON DELETE CASCADE 
	ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS comanda (
	id_comanda INT PRIMARY KEY AUTO_INCREMENT,
    id_func INT NOT NULL,
    id_pedido INT NOT NULL,
    id_mesa INT NOT NULL,
    FOREIGN KEY(id_func) REFERENCES funcionario (id_func),
    FOREIGN KEY(id_pedido) REFERENCES pedido (id_pedido),
    FOREIGN KEY(id_mesa) REFERENCES mesa (id_mesa)
    ON DELETE CASCADE 
	ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS produto_pedido (
	id_produto_pedido INT PRIMARY KEY AUTO_INCREMENT,
    qtd_produto INT NOT NULL,
    id_pedido INT NOT NULL,
    id_prod INT NOT NULL,
    FOREIGN KEY(id_pedido) REFERENCES pedido (id_pedido),
    FOREIGN KEY(id_prod) REFERENCES produto (id_prod)
    ON DELETE CASCADE 
	ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS pagamento (
	id_pag INT PRIMARY KEY AUTO_INCREMENT,
    total_pag DECIMAL(10,2) NOT NULL,
    total_pagado DECIMAL(10,2) NOT NULL,
    troco_pag DECIMAL(10,2),
    tipo_pag VARCHAR(50) NOT NULL,
    cpf_pag VARCHAR(50),
    id_pedido INT NOT NULL,
    FOREIGN KEY(id_pedido) REFERENCES pedido (id_pedido)
    ON DELETE CASCADE 
	ON UPDATE CASCADE
);

/*insercões*/
INSERT INTO cliente VALUES (default, "Gabrielle Silva", "gabi3@gmail.com", "gabi", "gabi123", "(11)91234-5678", default,default,default,default),
					       (default, "Leonardo Oliveira", "leo12@hotmail.com", "leo", "leo123", "(11)93421-9087", "87909-900", "Rua 7", 78, default);

INSERT INTO funcionario VALUES(default, "Joao Matos", "joao5@gmail.com", "joao", "joao12", "(11)92341-9087", 2),
							  (default, "Maria Lima", "maria23@hotmail.com", "maria", "maria45", "(11)97364-5276", 1),
                              (default, "Aline Carvalho", "aline96@gmail.com", "aline", "aline89", "(11)95544-9089", 3);

INSERT INTO mesa VALUES(default, 1, 4, "Vazia"),
					   (default, 2, 2, "Ocupada"),
                       (default, 3, 6, "Reservada");
                       
INSERT INTO pedido VALUES(default, '2021-09-21 07:05:09',"Pago"),
						 (default, '2021-08-25 20:00:56',"Pago"),
						 (default, '2021-09-22 21:05:09', "Aberto");
                         

INSERT INTO produto VALUES(default, "Proção pequena de sushi de salmão", "50 sushis em que o arroz é enrrolado em alga marinha e recheado com salmão cru", 12.05, "prato", "indisponível"),
						  (default, "Coca cola lata", "Lata de 300ml de coca-cola", 5.90, "Bebida", "disponível");

INSERT INTO reserva VALUES(default, 4, '2021-09-10 20:00:09',"Cliente compareceu", 2, 1),
						  (default, 5, '2021-10-10 18:00:25', "Pendente", 1, 2);

INSERT INTO carrinho VALUES(default, "06142-000", "Rua Agostinho Navarro", 987, "Torre 2 Apartament 5", 1, 1),
						   (default, "87909-900", "Rua 7", 78, default, 2, 1);

INSERT INTO comanda VALUES (default, 1, 3, 2);

INSERT INTO pagamento VALUES (default, 20.90, 20.90, default, "Cartao de débito", "234.889.876-65", 1);

INSERT INTO produto_pedido VALUES (default, 1, 1, 2);