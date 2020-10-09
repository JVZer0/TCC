drop database anuncioRoupa;

create database anuncioRoupa;

use anuncioRoupa;

create table tb_login(
	id_login 	int primary key auto_increment,
    ds_username	varchar(255)	not null,
    ds_senha	varchar(255)	not null
);

create table tb_usuario(
	id_usuario				int primary key auto_increment,
	nm_usuario				varchar(255),
    dt_nascimento			datetime,
    ds_sexo					varchar(50),
    ds_cpf					varchar(50),
    ds_rg					varchar(50),
    ds_email				varchar(255),
    ds_celular				varchar(50),
    ds_estado				varchar(50),
    ds_cidade				varchar(130),
    ds_cep					varchar(50),
    ds_endereco				varchar(255),
    ds_bairro				varchar(255),
    ds_n_endereco			varchar(50),
    ds_complemento_endereco	varchar(255),
    bt_concordo_termos		bool,
    id_login				int,
    foreign key (id_login) references tb_login(id_login) on delete cascade
);

create table tb_anuncio(
	id_anuncio				int primary key auto_increment,
	ds_titulo				varchar(255),
    ds_descricao			varchar(255),
    tp_produto				varchar(255),
    ds_condicao				varchar(255),
    ds_genero				varchar(60),
    nm_marca				varchar(255),
    ds_tamanho				varchar(50),
    vl_preco				decimal(15,2),
    ds_cep					varchar(50),
    bt_vendido				bool,
    ds_situacao				varchar(255),
    dt_publicacao			datetime,
    id_usuario				int,
    foreign key (id_usuario) references tb_usuario(id_usuario)
);

create table tb_imagem(
	id_imagem				int primary key auto_increment,
    img_anuncio				varchar(255),
    id_anuncio				int,
    foreign key (id_anuncio) references tb_anuncio(id_anuncio)
);

create table tb_favorito(
	id_favorito				int primary key auto_increment,
    bt_favorito				bool,
    id_usuario				int,
    id_anuncio				int,
    foreign key (id_usuario) references tb_usuario(id_usuario),
    foreign key (id_anuncio) references tb_anuncio(id_anuncio)
);

insert into tb_login(ds_username, ds_senha)
			  values('admin','1234');
insert into tb_login(ds_username, ds_senha)
			  values('IanHV','FHPutWujpe');
insert into tb_login(ds_username, ds_senha)
			  values('Lamorte','1234La');
insert into tb_login(ds_username, ds_senha)
			  values('DeanW','1234super');
              
insert into tb_usuario(nm_usuario, dt_nascimento, ds_sexo, ds_cpf, ds_rg, ds_email, ds_celular, ds_estado, ds_cidade, ds_cep, ds_endereco, ds_bairro, ds_n_endereco, ds_complemento_endereco, bt_concordo_termos, id_login)
				values('Ian Heitor Vieira','1946-11-19','Masculino','730.736.610-00','14.228.859-7','ianheitorvieira__ianheitorvieira@pibnet.com.br','(51) 99765-5038', 'RS', 'Porto Alegre','90640-002','Rua Vicente da Fontoura'
                ,'Rio Branco','284','',true,1);
insert into tb_usuario(nm_usuario, dt_nascimento, ds_sexo, ds_cpf, ds_rg, ds_email, ds_celular, ds_estado, ds_cidade, ds_cep, ds_endereco, ds_bairro, ds_n_endereco, ds_complemento_endereco, bt_concordo_termos, id_login)
				values('Paulo Fábio Ferreira','1972-10-14','Masculino','692.843.165-29','13.624.425-7','ppaulofabioferreira@pelozo.com.br','(68) 98215-6571', 'AC', 'Rio Branco','69915-314','Rua C'
                ,'Conjunto Habitacional Vila Betel 2','150','',true,2);
insert into tb_usuario(nm_usuario, dt_nascimento, ds_sexo, ds_cpf, ds_rg, ds_email, ds_celular, ds_estado, ds_cidade, ds_cep, ds_endereco, ds_bairro, ds_n_endereco, ds_complemento_endereco, bt_concordo_termos, id_login)
				values('Sophia Lara Antônia Almeida','1953-05-21','Feminino','608.726.034-07','48.846.719-6','sophialaraantoniaalmeida-72@thibe.com.br','(81) 99273-0238', 'PE', 'Igarassu','53625-213','2ª Travessa Jacob Pinto de Freitas'
                ,'Cruz do Rebouças','523','',true,3);
insert into tb_usuario(nm_usuario, dt_nascimento, ds_sexo, ds_cpf, ds_rg, ds_email, ds_celular, ds_estado, ds_cidade, ds_cep, ds_endereco, ds_bairro, ds_n_endereco, ds_complemento_endereco, bt_concordo_termos, id_login)
				values('José Cauã Nogueira','2002-05-12','Masculino','062.491.408-91','21.588.358-5','josecauanogueira-87@avantii.com.br','(92) 98783-4441', 'AM', 'Manaus','69090-799','Rua Doutor Solon Pinheiro'
                ,'Cidade Nova','423','',true,4);
                
insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario)
				values('bermuda obey camuflada','bermuda tamanho m obey camuflada, vai na altura do joelho um pouco pra cima','Bermuda','Usado','Masculino','obey','M',149.00,'90640-002',false,'Publicado','2020-09-25',1);
insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario)
				values('moletom amarelo nike','moletom tamanho m da nike ediçao especial track field, pouco usado, ótimo estado', 'Moletom','Usado','Masculino','nike','M',189.00,'69915-314',false,'Publicado','2020-09-25',2);                
insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario)
				values('Tenis Nike','Tenis Nike 12 molas', 'Tênis','Usado','Unisex','Nike','38',728.00,'53625-213',false,'Publicado','2020-09-25',3);
insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario)
				values('bermuda bmw bordado masculino','bermuda bmw bordado masculino tamanhos: m, g, gg, xxl.diversas cores: segue fotos.', 'Bermuda','Novo','Masculino','Puma','Diversos',145.00,'53625-213',false,'Publicado','2020-09-25',3);
                
insert into tb_imagem(img_anuncio, id_anuncio)
			   values('aionjfianfinaudnfa8935R89RFN3QU7D29',1);
insert into tb_imagem(img_anuncio, id_anuncio)
			   values('asdgf8ayg30f893vc3mg4j509vfio4hv78v34',2);
insert into tb_imagem(img_anuncio, id_anuncio)
			   values('va8jv94mnf4mvu8hvb0wnrg04nmv043mv8c7n9cq',3);
insert into tb_imagem(img_anuncio, id_anuncio)
			   values('davu849jf34c2378nc93jc30fj387v9-24jv9234nv4',4);
               
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio)
				  values(true,1,1);
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio)
				  values(true,1,3);
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio)
				  values(true,3,2);
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio)
				  values(true,3,4);
               
               
select * from tb_login;
select * from tb_usuario;
select * from tb_anuncio;
select * from tb_imagem;
select * from tb_favorito;


select * from tb_favorito f join tb_anuncio a on f.id_anuncio = a.id_anuncio join tb_usuario u on f.id_usuario = u.id_usuario where nm_usuario like "%Sophia%"