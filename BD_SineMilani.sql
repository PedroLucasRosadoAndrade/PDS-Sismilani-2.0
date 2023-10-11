# Grupo CineMilani

# - Ana Clara Santana da Silva
# - Bárbara Iaguita Oliveira Viera
# - Pedro Lucas Rosado Andrade
# - Dhenifer Regina Cavalieri
# - Nícolas Vailant Dutra Capila
# - Marco Antônio Duarte Guedes


drop schema if exists cinemilani_bd;
create database cinemilani_bd;
 use cinemilani_bd;
 
create table sala(
id_sal INT  primary key auto_increment ,
nome_sal varchar(50),
data_sal date,
hora_sal time ,
tamanho_sal varchar(50) ,
quantidade_sal INT
);

insert into sala  values (null, 'Ginni', '2023-05-04', '11:49','30 metros quadrados', 34);
insert into sala values(null, 'Rheta', '2022-10-11', '1:26','20 metros quadrados', 51);
insert into sala values (null, 'Dominik', '2023-01-15', '2:10 ','26 metros quadrados', 84);
insert into sala values (null, 'Laurel', '2023-05-12', '4:41 ','21 metros quadrados' ,94);
insert into sala  values (null, 'Gae', '2023-04-28', '3:18 ','29 metros quadrados', 42);
insert into sala  values (null, 'Jeremiah', '2023-06-18', '3:53 ','24 metros quadrados', 76);
insert into sala  values (null, 'Lorilyn', '2022-09-06', '8:58 ','22 metros quadrados', 61);
insert into sala values(null, 'Chane', '2023-05-21', '9:22 ','27 metros quadrados', 23);
insert into sala  values (null, 'Adelina', '2022-06-19', '9:14 ','23 metros quadrados', 85);
insert into sala values (null, 'Querida', '2022-12-31', '4:29','30 metros quadrados', 6);

create table estoque (
id_est int auto_increment  primary key,
unidade_est double ,
cod_est INT,
categoria_est VARCHAR(45),
validade_est DATE ,
valor_est FLOAT
);
  
insert into estoque values (null, 1, 1, 'Framing (Steel)', '2023-01-21', 47);
insert into estoque values (null, 2, 2, 'Site Furnishings', '2023-01-25', 26);
insert into estoque values (null, 3, 3, 'Termite Control', '2022-07-05', 6);
insert into estoque values (null, 4, 4, 'Hard Tile & Stone', '2022-07-05', 3);
insert into estoque values (null, 5, 5, 'Rebar & Wire Mesh Install', '2023-03-09', 32);
insert into estoque values (null,6, 6, 'Wall Protection', '2023-03-07', 21);
insert into estoque values (null,7, 7, 'Asphalt Paving', '2023-02-09', 37);
insert into estoque values (null ,8, 8, 'Site Furnishings', '2022-08-08', 23);
insert into estoque values (null, 9, 9, 'Soft Flooring and Base', '2022-11-19', 54);
insert into estoque values (null, 10, 10, 'Ornamental Railings', '2023-03-24', 13);
  
  select * from estoque;
  

CREATE TABLE Fornecedor (
  id_for INT  primary key auto_increment,
  Nome_for VARCHAR(45) NULL,
  CNPJ_for VARCHAR(45) NULL,
  tipo_for VARCHAR(45) NULL,
  telefone_for VARCHAR(45) NULL,
  historico_for VARCHAR(45) NULL
  );
  
  insert into fornecedor values (null, 'Coca-cola BR','56.985 567 123 67','bebidas','899996585656','Bom');
  insert into fornecedor values (null, 'PipocasLP BR','98.877 788 9898 98','Comida','8678686786','Bom');
  insert into fornecedor values (null, 'Frisck BR','66.555 7779 9768 67','bebidas','676786766','Bom');
  insert into fornecedor values(null,'POPcourn lift','12.233 345 532 34','Alimentos','POPCourn lift LTDA','ótimo');
  insert into fornecedor values(null,'Frisc spft','43.342 345 656 56','bebidas','Frisc spft LTDA','bom');
  insert into fornecedor values(null,'PMG atacadista','12.233 789 585 34','bebidas','PMG atacadista LTDA','bom');
  insert into fornecedor values(null,'Nova safra','12.233 789 585 34','bebidas','Nova safra LTDA','bom');
  insert into fornecedor values(null,'Canaã atacadista','12.233 789 585 34','bebidas','Canaã atacadista LTDA','bom');
  insert into fornecedor values(null,'Celeste Alimentos','12.233 789 585 34','bebidas','Celeste Alimentos LTDA','bom');
  
  CREATE TABLE Funcionario(
  id_fun INT  primary key auto_increment ,
  Nome_fun VARCHAR(45) NULL,
  nascimento_fun DATE ,
  sexo_fun VARCHAR(45) ,
  cpf_fun VARCHAR(45) ,
  salario_fun FLOAT ,
  funcao_fun VARCHAR(45) ,
  email_fun VARCHAR(45) ,
  telefone_fun VARCHAR(45),
  rg_fun VARCHAR(45) 
  );
insert into funcionario value(null,'Carlos Alberto','1929-09-09','masculino','123.123.123-32',1450,'segurança','carlos@gmail.com','89 999876544','1232 Ro');
insert into funcionario values (null,'Ana alice','2008-09-12','feminino','123.212.332-23',21233,'atendente','ana@gmail.com','12 2323232323','121212 SP');
insert into funcionario values (null,'William shakespier','2012-08-23','masculino','123.212.333-23',1231,'segurança','will@gmail.com','12 22424222222','5465464 SP');
insert into funcionario values (null,'Kaue lombarde','2021-09-09','masculino','123.111.332-23',13133,'gerente de salas','kaue@gmail.com','12 6468464646','3165566 SP');
insert into funcionario values (null,'Camila caio','2003-07-06','feminino','123.221.111-23',23232,'atendente','Camila@gmail.com','12 2132131313','23135 SC');
insert into funcionario values (null,'Felipe miller','2001-09-05','masculino','123.444.323-32',3433,'gerente','felipe@gmail.com','12 549848998987','56468 SC');
insert into funcionario values (null,'Maria alice santos','2000-06-04','feminino','123.000.332-12',43434,'atendente','Mari@gmail.com','12 354648987','6546546 SC');
  
create table produto(
id_prod int  primary key auto_increment,
nome_prod VARCHAR(50),
Marca_prod VARCHAR(45) ,
tipo_prod VARCHAR(45),
quantidade_prod INT ,
validade_prod DATE,
valor_prod FLOAT,
id_for_fk int,
foreign key (id_for_fk) references fornecedor (id_for),
id_est_fk int,
foreign key (id_est_fk) references estoque (id_est)
);
insert into produto values (null, 'Refrigerante', 'Coca Cola', 'Perecivel',20, '2022-07-03',300,1,2);
insert into produto  values (null, 'Piopoca','Doces LTDA','Tangíveis',45,'2022-09-03',360,2,3);
insert into produto  values (null, 'Aguá','AZEDO LTDA','Pericivel', 71, '2023-05-18',789,2,3);
insert into produto  values (null, 'Salgadinho','SALDADOS LTDA','Tangíveis',69,'2022-12-27',1250,3,3);
insert into produto  values (null, 'Suco','Pitanco', 'Perecivel', 33, '2022-08-02',789.78,3,4);

 create table produtora (
  id_produ INT  primary key auto_increment,
  Nome_produ VARCHAR(50) NULL,
  CNPJ_produ VARCHAR(45) NULL,
  telefone_produ VARCHAR(45) NULL,
  razaoSocial_produ VARCHAR(45) NULL,
  Tipo_produ VARCHAR(45) NULL,
  historico_produ varchar(100) 
  );
  
  insert into produtora values(null, 'Marvel BR','66.111 222 2343 22','678686876','malvel LTDA','filmes','Bom');
  insert into produtora values(null, 'WB BR','21.111 234 1223 12','678686876','WB LTDA','filmes','Bom');
  insert into produtora values(null,'WLS films','12.333 333 333 33','678686876','WLS LTDA','filmes','ótimo');
  insert into produtora values(null,'Disney land','12.233 345 532 34','678686876','Disney LTDA','filmes','ótimo');
  insert into produtora values(null,'MGM ','12.233 345 532 34','678686876','filmes','MGM LTDA','ótimo');
  insert into produtora values(null,'Paramount ','12.233 345 532 34','678686876','Paramount LTDA','filmes','ótimo');
  insert into produtora values(null,'Century fox','12.233 345 532 34','678686876','Cantury LTDA','filmes','ótimo');
  insert into produtora values(null,'Universal pictures ','12.233 345 532 34','678686876','Universal LTDA','filmes','ótimo');
  insert into produtora values(null,'Time Warner ','12.233 345 532 34','678686876','Time LTDA','filmes','ótimo');
 
  create table filme(
  id_film INT  primary key auto_increment,
  atores_film VARCHAR(45) ,
  sinopse_film VARCHAR(100) ,
  elenco_film VARCHAR(45) ,
  fornecedor_film VARCHAR(45) ,
  data_film DATE,
  dataLancamento_film date,
  titulo_film VARCHAR(45),
  categoria_film VARCHAR(45),
  diretor_film VARCHAR(45) ,
  id_sal_fk int,
  foreign key(id_sal_fk) references sala(id_sal),
  id_prod_fk int,
  foreign key(id_prod_fk)references produtora(id_produ)
  );
  
insert into filme  values (1, 'Delmar', 'sim', 'Dianna', 'Lulu', '2022-10-16', '2022-10-16', 'House on 92nd Street, The', 'livre', 'HVAC', 1,1);
insert into filme  values (2, 'Estel', 'sim', 'Goddart', 'Clementius', '2022-10-16', '2023-05-24', 'Compulsion', 'livre', 'Asphalt Paving', 1,2);
insert into filme  values (3, 'Louise', 'sim', 'Ardine',  'Deloria', '2022-10-16', '2022-12-18', 'My Demon Lover', 'livre', 'Soft Flooring and Base', 2,3);
insert into filme  values (4, 'Lonni', 'sim', 'Geri',  'Deina', '2022-10-16', '2023-04-25', 'Sleepy Time Gal, The', '+18', 'Asphalt Paving', 1,3);
insert into filme  values (5, 'Mac', 'sim', 'Rayner', 'Kennan', '2022-10-16', '2022-11-13', 'Waiting Game, The', 'livre', 'Prefabricated Aluminum Metal Canopies', 2,4);
insert into filme  values (7, 'Xymenes', 'sim', 'Drusy',  'Ariana', '2022-10-16', '2022-07-13', 'Wrong Turn at Tahoe', 'livre', 'Structural and Misc Steel (Fabrication)', 3,4);
insert into filme values (8, 'Dorian', 'sim', 'Jacob',  'Carol-jean', '2022-10-16', '2022-08-06', 'Adventures of Power', 'livre', 'Granite Surfaces', 3,2);
insert into filme  values (9, 'Elvin', 'sim', 'Rafaellle',  'Hetty','2023-01-21', '2023-04-21', 'Final Destination', 'livre', 'Painting & Vinyl Wall Covering', 1,3);
  
  
  CREATE TABLE Caixa (
  id_cai INT  primary key auto_increment,
  dataInicial_cai DATE ,
  horaAbertura_cai TIME ,
  horaFechamento_cai TIME ,
  saldoFinal_cai FLOAT,
  saldoInicial_cai FLOAT ,
  id_fun_fk int,
 foreign key (id_fun_fk) references funcionario(id_fun)

);
insert into caixa values(null,'1989-12-06','21:30','22:40',5000,6000,1);
insert into caixa values(null,'1989-04-24','20:15','22:40',1500,5300,3);
insert into caixa values(null,'1989-05-25','09:12','20:40',5000,6000,2);
insert into caixa values(null,'1989-03-07','08:30','10:40',1450,1500,4);
insert into caixa values(null,'1989-07-21','20:30','22:40',6000,1530,5);
insert into caixa values(null,'1989-01-23','22:45','23:40',5000,7000,3);
insert into caixa values(null,'1989-07-22','23:30','00:40',4500,5000,2);

create table despesa(
id_desp int  primary key auto_increment,
descricao_desp VARCHAR(45) ,
cnpj_desp VARCHAR(45) ,
forma_pag_desp VARCHAR(45) ,
valor_desp FLOAT ,
data_desp DATE 
);
insert into despesa  values (null, 'Brook', '12.345.678/0001-00', 'Dineheiro',6,'2002-09-09');
insert into despesa  values (null, 'Ty', '12.345.678/0002-00','Cartão',1900,'2002-02-09');
insert into despesa  values (null, 'Debora', ' 12.345.678/0003-00','Pix', 100, '2023-06-09');
insert into despesa  values (null, 'Mariam', ' 12.345.90/0003-00','Boleto', 140, '2022-08-27');
insert into despesa  values (null, 'Bryn', '16.811.931/0001-00','Transferemcia',419, '2023-02-03');
insert into despesa  values (null, 'Ferdinand', '33.050.071/0001-58','Dineheiro', 317, '2022-06-25');
insert into despesa  values (null, 'Tarrance','0.359.742/0001-08','Pix',691, '2023-04-10');
insert into despesa  values (null, 'Gunter', '9.922.456/0934-09','Cheque', 990, '2022-10-31');
insert into despesa  values (null, 'Erasmus','08.364.948/0001-38','Boleto',826, '2022-08-19');
insert into despesa  values (null, 'Winni', '08.364.948/0001-36','Cartão', 502, '2022-11-04');

create table pagamento (
id_pag int  primary key auto_increment,
valor_pag FLOAT,
forma_pag VARCHAR(45),
empresa_pag VARCHAR(50) ,
sigla_pag VARCHAR(45) ,
cpf_devedor_pag VARCHAR(45) ,
telefone_devedor_pag varchar(30),
descicao_pag VARCHAR(50) ,
hora_pag TIME ,
data_pag DATE ,
id_cai_fk int,
foreign key(id_cai_fk) references Caixa(id_cai),
id_desp_fk int,
foreign key(id_desp_fk) references Despesa(id_desp)
);

insert into Pagamento values(null, 564,'Cartão','Banco do Brsil','BD','70345678902' , '(24) 3536-4239','aberto','12:09:00','2021-05-06',  null,null);
insert into Pagamento values(null, 545,'Pix','Best Place','BP','72375678956','(67) 2831-2415', 'aberto','16:09:00', '2021-10-21', null,null);
insert into Pagamento values(null, 5145,'Boleto','Inovare','IN','51345674902','(83) 3569-0884','fechado','12:20:00', '2021-11-30',null,null);
insert into Pagamento values(null, 4452, 'Cartão','Cultural Store','CS', '70395670902','(47) 2948-7438', 'fechado','5:09:00', '2021-07-09',null,null);
insert into Pagamento values(null, 5145,'PIX','Best Place','BP','70325677902','(97) 3354-7837', 'fechado','19:09:00','2021-11-30',null,null);
insert into Pagamento values(null, 5145,'Dinheiro','Universo','UN','98325678902', '(28) 3702-6882', 'fechado','23:09:00','2021-11-30',null,null);

CREATE TABLE vendas (
  id_ven INT primary key auto_increment,
  Data_ven DATE NULL,
  hota_ven TIME NULL,
  quantidade_ven INT NULL,
  descricao_ven VARCHAR(50) NULL,
  valor_ven FLOAT NULL,
  recebimento_id_rec INT NOT NULL,
  Funcionario_id_fun INT NOT NULL,
  id_fun_fk  int,
  foreign key(id_fun_fk) references funcionario(id_fun)
  );
  
  create table ingresso(
  id_ing INT  primary key auto_increment,
  duracao_ing TIME NULL,
  tipo_ing VARCHAR(45) NULL,
  valor_ing FLOAT NULL,
  hora_ing TIME NULL,
  nome_ing VARCHAR(45) NULL,
  dataInicial_ing DATE NULL,
  dataFinal_ing DATE NULL,
  formaPag_ing VARCHAR(45) NULL,
  filme_id_film_fk INT NOT NULL,
  foreign key(filme_id_film_fk) references filme (id_film),
  sala_id_sal_fk INT NOT NULL,
  foreign key(sala_id_sal_fk) references sala (id_sal),
  Pagamento_id_pag_fk INT NOT NULL,
  foreign key(Pagamento_id_pag_fk) references pagamento(id_pag)
  #id_ven_fk INT,
  #foreign key(id_ven_fk) references vendas(id_ven)
  );
  
  insert into ingresso values(null, '02:20','normal','12.20','14:30','Lilian martins','2023-06-12', '2023-06-12','Cartão de crédito',1,1,1);
  insert into ingresso values(null, '03:30','Meia','13.32','15:30','willian Juliana','2023-06-10', '2023-06-10','Cartão de Débito',2,2,2);
  insert into ingresso values(null, '01:20','normal','22.20','23:30','Luana Gonçalves','2023-06-09', '2023-06-09','Pix',3,3,1);
  insert into ingresso values(null, '02:20','dupla','12.34','13:20','Ana Mirian','2023-06-05', '2023-06-05','Cartão de crédito',1,2,2);
  insert into ingresso values(null, '01:20','meia','22.20','13:30','Hugo Chaves','2023-06-04', '2023-06-04','Cartão de crédito',1,4,2);
  insert into ingresso values(null, '01:20','meia','23.20','01:30','Diego Lifet','2023-06-03', '2023-06-03','Cartão de Débito',5,1,2);
  insert into ingresso values(null, '01:20','normal','21.20','22:30','Kaio Felipe','2023-06-02', '2023-06-02','pix',3,1,4);
  insert into ingresso values(null, '01:30','meia','11.21','12:30','Sabrina Vieira','2023-06-01', '2023-06-01','Cartão de crédito',2,3,1);
  insert into ingresso values(null, '02:20','meia','22.20','13:30','Fernandes martins','2023-06-15', '2023-06-15','pix',1,3,2);
  insert into ingresso values(null, '02:20','simples','19.20','20:30','Maria lilian','2023-06-13', '2023-06-13','pix',1,4,2
  );
  
  create table login(
id_log int  primary key auto_increment,
email_log VARCHAR(100) ,
usuario_log VARCHAR(45) ,
senha_log VARCHAR(45),
id_fun_fk int,
foreign key (id_fun_fk) references funcionario(id_fun)
);

insert into login (id_log , email_log , usuario_log, senha_log) values (1, 'egolagley0@ow.ly', 'eunwins0', 'xL8.yNYn40');
insert into login (id_log , email_log , usuario_log, senha_log) values (2, 'kconstance1@comcast.net', 'alamb1', 'hM4(p/d$%GuMee1');
insert into login (id_log , email_log , usuario_log, senha_log) values (3, 'eelflain2@msn.com', 'jyokelman2', 'nH4_w41y>o');
insert into login (id_log , email_log , usuario_log, senha_log) values (4, 'ecockman3@skyrock.com', 'lcuredell3', 'wP5>dmM"ueg%03');
insert into login (id_log , email_log , usuario_log, senha_log) values (5, 'khartfleet4@huffingtonpost.com', 'jpabst4', 'vR6<X@KdJCo%Yy');
insert into login (id_log , email_log , usuario_log, senha_log) values (6, 'kbirchenhead5@about.me', 'rziems5', 'hI9\x0|<=?>B<2');
insert into login (id_log , email_log , usuario_log, senha_log) values (7, 'eely6@army.mil', 'rchalke6', 'nW9(y(*RB');
insert into login (id_log , email_log , usuario_log, senha_log) values (8, 'crobyns7@npr.org', 'asalkeld7', 'nD3=_q6l2PEQGt%');
insert into login (id_log , email_log , usuario_log, senha_log) values (9, 'arockey8@engadget.com', 'helliff8', 'xA4{SfmB5w''n!%&');
insert into login (id_log , email_log , usuario_log, senha_log) values (10, 'hvautrey9@ameblo.jp', 'fsimmings9', 'cP1_`/3p');
  
create table cliente(
 id_cli int  primary key auto_increment ,
  nome_cli VARCHAR(50) ,
  rg_cli VARCHAR(45) ,
  telefone_cli VARCHAR(45) ,
  email_cli VARCHAR(45) ,
  data_nasc_cli DATE ,
  cpf_cli VARCHAR(45) ,
  sexo_cli VARCHAR(45) ,
  endereco_cli varchar(100)
  );

  
  insert into cliente values (null,'Ana Silva','12 345 678-9','69 99205678','ana@gmail.com','2005-08-21','34567889065','Femenino','Vila de Rondônia');
  insert into cliente values (null,'Dhenifer Silva','12 345 678-9','69 99305678','dhenifer@gmail.com','2005-08-21','34567889065','Femenino','Avenia Rossi');
  insert into cliente values (null,'Pedro Silva','17 545 678-9','69 99205678','pedro@gmail.com','2001-08-21','34567889065','Femenino','Vila Nova');
  insert into cliente values (null,'Sabrina Silva','12 785 078-7','69 99255678','sabrina@gmail.com','2008-08-21','34567889065','Femenino','São Martins');
  insert into cliente values (null,'Tainara Silva','18 305 328-1','69 99205458','tainara@gmail.com','2009-08-21','34567889065','Femenino','São Lucas');
  insert into cliente values (null,'Nathália Silva','12 245 618-3','69 99205678','nathalia@gmail.com','2005-08-21','34567889065','Femenino','Avenia sete de setembro');
  insert into cliente values (null,'Raylany Silva','32 145 342-9','69 99204578','raybaly@gmail.com','2002-08-21','34567889065','Femenino','Avenida Brasilia');
  insert into cliente values (null,'Marcos Silva','82 245 889-1','69 99123678','marcos@gmail.com','2004-08-21','34567889065','Femenino','Avenida Natalino ');
  insert into cliente values (null,'Bárbara Silva','16 349 878-6','69 99123678','barbara@gmail.com','2006-08-21','34567889065','Femenino','Vila de Rondônia');
  insert into cliente values (null,'Nicolau Silva','11 545 688-7','69 99805978','nico@gmail.com','2003-08-21','34567889065','Femenino','Vila de Rondônia');
  
select * from cliente;


 
 create table Recebimento(
  id_rec int auto_increment  primary key,
  descricao_rec VARCHAR(45),
  status_rec VARCHAR(45),
  valor_rec FLOAT,
  date_rec DATE,
  id_cai_fk int,
  foreign key (id_cai_fk) references caixa (id_cai)
  );
  
insert into Recebimento  values (1, 'Robb', null, 123, '2022-10-19', 3);
insert into Recebimento  values (2, 'Karol', null, 131, '2022-08-11', 4);
insert into Recebimento  values (3, 'Simonne', null, 1313, '2023-03-19', 4);
insert into Recebimento  values (4, 'Onfre', null, 23424, '2023-03-15', 7);
insert into Recebimento  values (6, 'Lenore', null, 2424, '2023-04-24', 5);
insert into Recebimento values (7, 'Meredith', null, 2432, '2022-12-23', 2);
insert into Recebimento  values (8, 'Sherline', null, 2424, '2023-03-18', 1);
insert into Recebimento  values (9, 'Gracie', null, 234324, '2022-12-12', 5);
insert into Recebimento values (10, 'Roldan', null, 23424, '2022-07-06', 1);

  
  create table vendas_Produto(
id_ven_prod int primary key auto_increment,
id_prod_fk int,
foreign key(id_prod_fk) references Produto(id_prod),
id_ven_fk int,
foreign key(id_ven_fk) references vendas(id_ven)
);


CREATE TABLE Poltrona (
  id_pol INT  primary key auto_increment,
  fileira_pol INT, 
  numero_pol INT,
  tipo_pol varchar(100),
  local_pol varchar(100),
  Poltronacol VARCHAR(45) ,
  id_sal_fk Int,
  foreign key(id_sal_fk) references sala (id_sal),
  id_ing_fk INT ,
  foreign key(id_ing_fk) references Ingresso(id_ing)
);

insert into poltrona values(null,1,3,'simples','lado esquerdo da porta de entrada','S2',1,2);
insert into poltrona values(null,2,2,'vip','lado esquerdo da porta de entrada','S2',2,2);
insert into poltrona values(null,3,22,'simples','lado esquerdo da porta de entrada','S3',3,1);
insert into poltrona values(null,4,24,'dupla','lado esquerdo da porta de entrada','S3',2,5);
insert into poltrona values(null,15,13,'simples','lado esquerdo da porta de saida','S2',5,1);
insert into poltrona values(null,13,12,'vip','lado esquerdo da porta de saida','S3',1,3);
insert into poltrona values(null,12,22,'vip','lado direito da porta de entrada','S3',1,1);



CREATE TABLE Serie (
  id_ser INT primary key,
  nome_ser VARCHAR(45) NOT NULL,
  genero_ser VARCHAR(45) NULL,
  classificascao_ser VARCHAR(45) NOT NULL,
  episodios_ser INT NULL,
  numero_temporadas INT NULL,
  quantidade_ser INT NULL,
  data_lancamento_ser VARCHAR(45) NULL,
  sinopise_ser VARCHAR(45) NULL
  );
  
  
  
   #--------------- PROCEDIMENTOS |   ---------------
   
     delimiter $$
  create procedure salvar_sala (nome varchar(50),data_sal date,hora time,tamanho varchar(50),quantidade INT)
  begin
    if( nome <> '') and (hora <> '') and (tamanho <> '') then
        insert into sala values (null,nome,data_sal,hora,tamanho,quantidade);
          select 'A sala foi salvo com sucesso!' as Confirmação;
  else
        select 'Os campos Nome,Tamanho e Hora são obrigatorios!' as Alerta;
  end if;
  end
  $$ delimiter ;
  
  call salvar_sala ('','2023-05-24','20:00','23 metros quadrado',5);
  
  select * from sala;
  

delimiter $$
create procedure salvar_estoque(unidade double,cod int,categoria varchar(45),validade date,valor float)
begin
 if( unidade <> '') and (categoria <> '') and (cod<> '') then
	insert into estoque values(null,unidade,cod,categoria,validade,valor);
      select 'Estoque salvo com sucesso!' as Confirmação;       
 else
     select 'Os campos Unidade,Cod e Categoria são obrigatorios!' as Alerta;
 end if;
 end;
$$ delimiter ;

  call salvar_estoque(5,5,'','2023-09-21',26.60);
  
  #select * from estoque;
  
  
  delimiter $$
  create procedure salvar_fornecedor( Nome VARCHAR(45),CNPJ VARCHAR(45),tipo VARCHAR(45),telefone VARCHAR(45),historico VARCHAR(45))
  begin  
    if(   Nome <> '') and (cnpj <> '') and (telefone <> '')  then
    	insert into fornecedor values(null,nome,cnpj,tipo,telefone,historico);
		  select 'Fornecedor salvo com sucesso!' as Confirmação;       
    else
		select 'Os campos NomeFantasia,CNPJ e Telefone são obrigátorios!' as Alerta;
     end if;
     end;
  $$ delimiter ;
  
call salvar_fornecedor('','98.867 768 9898 88','bebidas','69 96104456','Bom');

#select * from fornecedor;

delimiter $$ 
create procedure salvar_Funcionario (Nome varchar (300), nascimento date, sexo varchar(60), cpf varchar(50), salario float, funcao varchar (54), email varchar(100), telefone varchar(100), rg varchar(50))
begin
 if (Nome <> '')and (sexo <> '')and (telefone <> '') then 
		insert into funcionario values (null, nome, nascimento,sexo, cpf, salario, funcao, email, telefone, rg);
			Select 'Funcionario Cadastrado com Sucesso' as Confirmação;
 else
		select 'Os campos NOME,Sexo e Telefone são  obrigátorios!' as alerta;
      
	end if;
end;
$$ delimiter ;  

Call salvar_Funcionario('', '2023-09-23','feminino', '123.456.789-10', '1000000', 'Chefe', 'dheniferreginajm@gmail.com', '69 993982586', '5555555');

delimiter $$ 
create procedure salvar_produto (nome varchar (200), Marca varchar(98), tipo varchar(50), quantidade int, validade date, valor float,Fornecedor_fk int,estoque_fk int)
begin
 if (Nome <> '')and (Marca <> '')and (quantidade <> '') then 
		insert into produto values (null, nome, Marca, tipo, quantidade, validade, valor,fornecedor_fk,estoque_fk);
                Select 'Produto Cadastrado com Sucesso' as Confirmação;
 else
 
		select 'Os campos NOME,MARCA e QUANTIDADE são  obrigátorios!' as alerta;
	end if;
end;
$$ delimiter ;  

Call salvar_produto('', 'yoki', 'salgada', 20 , '2023-12-12',  20.00,2,3); 
Select * from

  delimiter $$ 
create procedure salvar_produtora (Nome varchar(200), CNPJ varchar(98), telefone varchar(50), razaoSocial varchar(54), Tipo varchar(165), historico varchar(648))
begin
 if (Nome <> '')and (telefone <> '')and (historico <> '') then 
		insert into produtora values (null, Nome, CNPJ, telefone, razaoSocial, Tipo_produ, historico_produ);
			Select 'Produtora Cadastrado com Sucesso' as Confirmação;
 else
 
 		select 'Os campos NOME,TELEFONE e HISTORICO_PRODU são  obrigátorios!' as alerta;
	end if;
end;
$$ delimiter ;

Call salvar_produtora('', '22.333.333/0001-00', '69958455415', 'eventos', 'filmes', 'em alta');

  DELIMITER $$
  
  create procedure SalvarFILME (atores varchar(100), sinopse varchar(200), elenco varchar(200),
  fornecedor varchar(20),dataFilme date, dtLancamento date, titulo varchar(100), categoria varchar(20),
  diretor varchar(50), sala_id int, produtora_id int)
  BEGIN

	if(titulo <> '') then
			insert into  filme values(null, atores, sinopse, elenco, fornecedor, dataFilme, dtLancamento, titulo,
			categoria, diretor,sala_id, produtora_id);
			select  concat(' O ', titulo, ' foi inserido com sucesso!') as Informacao;
	else
    select 'O campo TITULO deve ser preenchido!' as Alerta;
    
    end if ;
   
  end ;
  $$ DELIMITER ;
  
  CALL SalvarFILME('Delmar', 'sim', 'LILIAN', 'Lulu', '2022-10-16', '2022-10-16', 'House on 92nd Street, The', 'livre', 'HVAC', 1, 1);
  CALL SalvarFILME('Goes', 'sim', 'Maira', 'the Rock', '2023-08-06', '2023-03-06', 'Homem Aranha', 'livre', 'MARVEL', 2, 1);
  CALL SalvarFILME('Silva', 'não', 'JK', 'Moni', '2020-07-23', '2022-01-03', '', '+16', 'HBO', 2, 2);


DELIMITER $$

create procedure Caixa (dtInicial date,horaAbertura time, horaFechamento time, saldoF float,
saldoInicial float, id_funcionario int)
begin

if (horaFechamento <> '') then
		insert into caixa values(null,dtInicial, horaAbertura, horaFechamento, saldoF, saldoInicial,
		id_funcionario);
			select 'O caixa foi fechado corretamente.' as Confirmação;
else
	select ' A HORA deve ser inserida no sistema!' as Alerta;
end if ;

end;
$$ DELIMITER ;  
  call Caixa ('2022-09-09', '13:00','14:50',1200.60, 50.00, 1);
  call Caixa ('2022-09-10', '13:00','17:30',2000.00, 100.00, 3);
  call Caixa ('2022-09-12', '13:00','18:30',2000.00, 100.00, 3);
  
DELIMITER $$
create procedure Despesa (descricao varchar(200), cnpj varchar(11), FormaPagamento varchar(100), valor float,
dataDespesa date) 
begin
if(cnpj <> '')then
	insert into despesa values(null, descricao, cnpj, FormaPagamento, valor, dataDespesa);
	select concat(' Despesa ', descricao, ' salva com sucesso!') as Confirmação;
else
	select'O numero do CPF deve ser inserido.' as Alerta;
end if;
end;
$$ DELIMITER 

call despesa ('internet', '11111111111', 'Cartao', 12.00, '2022-09-09'); 
call despesa ('Limpesa de salas ', '1', 'Cartao', 12.00, '2022-09-09'); 
call despesa ('luz', '', 'Cartao', 12.00, '2022-09-09'); 

delimiter $$

create procedure pagamento_correto (valor FLOAT,formaPagamento varchar(100),empresa varchar(50),sigla varchar(45),cpf_devedor varchar(45),telefone_devedor varchar(30),descricao_pag varchar(50),horaPagamento TIME,dataPagamento DATE)
begin
    if (valor IS NOT NULL) then
        insert into Pagamento (valor_pag, forma_pag, empresa_pag, sigla_pag, cpf_devedor_pag, telefone_devedor_pag, descicao_pag, hora_pag, data_pag)
        values (valor, formaPagamento, empresa, sigla, cpf_devedor, telefone_devedor, descricao_pag, horaPagamento, dataPagamento);
        select concat('O Pagamento ', valor, ' foi salvo com sucesso!') as Confirmacao;
    else
        select 'O campo VALOR é obrigatório!' as Alerta;
    end if;
end;
$$

delimiter ;

call pagamento_correto(600, 'Dinheiro', 'pedor', 'fs', '123.456.789-01', '(28) 4002-8922', 'ABERTO', '12:10:00', '2020-11-30');
#select * from Pagamento;

delimiter $$

delimiter $$

create procedure vendas_correta (dataVenda DATE, hora TIME, quantidade INT, descricao VARCHAR(50), valorVenda FLOAT, recebimento_id_rec INT, Funcionario_id_fun INT)
begin
    if (dataVenda IS NOT NULL) then 
        insert into vendas (Data_ven, hota_ven, quantidade_ven, descricao_ven, valor_ven, recebimento_id_rec, Funcionario_id_fun)
        values (dataVenda, hora, quantidade, descricao, valorVenda, recebimento_id_rec, Funcionario_id_fun);
        select concat('A venda do dia ', dataVenda, ' foi salva com sucesso!') as Confirmacao;
    else
        select 'O campo Data da venda é obrigatório!' as Alerta;
    end if;
end;

$$ delimiter ;

call vendas_correta('2024-09-20', '23:09:00', 40, 'Coka 2l', 600, 1, 2);

select * from vendas;
  
delimiter $$

create procedure ingresso_correto (duracao TIME,tipo VARCHAR(45),valor FLOAT,hora TIME,nomeIng VARCHAR(45),dataInicial DATE,dataFinal DATE,formaPag VARCHAR(45))
begin
    if (nomeIng <> '') then
        insert into ingresso (duracao_ing, tipo_ing, valor_ing, hora_ing, nome_ing, dataInicial_ing, dataFinal_ing, formaPag_ing)
        values (duracao, tipo, valor, hora, nomeIng, dataInicial, dataFinal, formaPag);
        select concat('O NOME ', nomeIng, ' foi salvo com sucesso!') as Confirmacao;
    else
        select 'O campo NOME é obrigatório!' as Alerta;
    end if;
end;
$$ delimiter ;

 #call ingresso_correto('03:20', 'cheia', 24.20, '12:30', 'cotia martins', '2022-05-17', '2022-05-18', 'cartao');

#select * from ingresso;

  delimiter $$
create procedure login ( email varchar(90), usuario varchar(90), senha varchar(90), fk_func int)
begin

if (usuario <> '') and (senha <> '') then
insert into login values (null, email , usuario, senha, fk_func);

select 'login efetuado com sucesso!' as Confirmação;

else 
		select 'Os campos USUARIO e LOGIN são obrigatorios!' as Alerta;

end if;
end;
$$ delimiter ;

call login('augmen@gmail.com', 'fawe42', 'login123', 3);
call login('gasd@gmail.com', 'onlineUser', '#0621', 1);
call login('dfghdasfdfggd@gmail.com', 'jacksonUser', 'das521', 1);
#select * from login;

delimiter $$
create procedure cliente (nome VARCHAR(50) , rg VARCHAR(45) ,telefone VARCHAR(45) , email VARCHAR(45) ,data_nasc DATE ,cpf VARCHAR(45) ,sexo VARCHAR(45), endereco varchar(100))
begin

if (nome <> '') and (rg <> '') and (cpf <> '') then
insert into cliente values (null, nome, rg, telefone, email, data_nasc, cpf, sexo, endereco);

select 'Cliente cadastrado com sucesso!' as Confirmação;

else 
		select 'Os campos NOME, RG, CPF e CEP são obrigatorios!' as Alerta;

end if;
end;
$$ delimiter ;

call cliente  ('juana Silva','23 457 43-9','69 99205128','asss@gmail.com','2005-08-21','34567889065','Femenino','Vila de Rondônia');
call cliente  ('Stefany thaiis ','52 345 678-9','69 99342578','FANNY@gmail.com','2005-08-21','34567889065','Femenino','Avenia Rossi');
call cliente  ('lucas Silva','12 623 623-9','69 99202365','sad@gmail.com','2001-08-21','34567889065','Femenino','Vila Nova');
 
 #select * from cliente;
 
   delimiter $$
create procedure recebimento ( descricao varchar(90), status_1 varchar(90), valor float, data_1 date,  cai_fk int)
begin

if (descricao <> '') and (status_1 <> '') then
insert into recebimento values (null, descricao , status_1, valor, data_1, cai_fk);

select 'Recebimento finalizado com sucesso!' as Confirmação;

else 
		select 'Os campos DESCRICAO e STATUS são obrigatorios!' as Alerta;

end if;
end;
$$ delimiter ;

call recebimento('JACKSON', 'pago', 14.50, '2023-10-09', 2);
call Recebimento('Karol', 'Devendo', 131, '2022-08-11', 1);
call Recebimento('Simonne', 'pago', 1313, '2023-03-19', 4);

#select * from recebimento;

  
   #DELIMITER $$
 #Create Procedure Recebimento ( descricao_rec VARCHAR(45),status_rec VARCHAR(45), valor_rec varchar(45), date_rec DATE,Caixa_fk int)
  #Begin 

 
	 #If(descricao_rec <> '') Then 
    # Insert Into Recebimento Values (null, descricao, status_rec, valor_rec,  date_rec, caixa_fk);
	
	 #Select 'RECEBIMENTO CADASTRADO!' as Confirmação;
        
	 #Else
	 #Select 'O campo esta incorreto!' as Alerta;
 
	 #End if;
 
  #End;
 
 #$$ DELIMITER ;
 
 #Call Recebimento('marco', null ,444, '2000-06-09', 2);



 #Select * from Recebimento;

  DELIMITER $$
 Create Procedure Poltrona (fileira varchar(40),  numero INT,tipo varchar(100), local_pol varchar(100), Poltronacol VARCHAR(45), Sala_fk int, Ingresso_fk int )
 Begin 

 
	If(fileira <> '') Then 
    Insert Into Poltrona Values (null, fileira, numero, tipo, local_pol, Poltronacol, Sala_fk , Ingresso_fk);
	
	Select 'POLTRONA CADASTRADA!' as Confirmação;
        
	Else
	Select 'O campo esta incorreto!' as Alerta;
 
	End if;
 
 End;
 
$$ DELIMITER ;
 
Call Poltrona('', '2', 'pequena', 'sala 2', 2, 3,2);
Call Poltrona('4', '2', 'pequena', 'sala 2', 2, 3,2);



Select * from Poltrona;
  
  DELIMITER $$
 Create Procedure Serie (nome Varchar(45),  genero Varchar(45), classificacao varchar(45), episodios Int, numero_temporadas int, quantidade int, data_lancamento varchar(45), sinopse varchar(45))
 
 Begin 
	IF (nome <> '' AND genero <> '' AND classificacao <> '' AND episodios IS NOT NULL
        AND numero_temporadas IS NOT NULL AND quantidade IS NOT NULL
        AND data_lancamento IS NOT NULL AND sinopse <> '') THEN 
       Insert Into serie Values (nome, genero, classificacao, episodios, numero_temporadas, quantidade , data_lancamento , sinopse);
	
	Select 'SERIE CADASTRADA!' as Confirmação;
        
	Else
	Select 'O campo esta incorreto!' as Alerta;
 
	End if;
 
 End;
 
$$ DELIMITER ;
 
#CALL Serie('tudo explosivo', 'acao', 'boa', 100, 2, 5, '2023-09-09', 'uma das melhores series de ação');
#CALL Serie('acao','ação', 'boa', 100, 2, 5, '2023-09-09', 'uma das melhores series de ação');



Select * from Serie;