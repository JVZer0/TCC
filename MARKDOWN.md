![](https://i.imgur.com/IJbxAed.jpg)

# Relatório e Analise do Sistema de Anuncios.

:::info
TK Soluçõees de infórmatica
:::

***

## Equipe:sunglasses:

- Samuel Fiuza 
- Kaun Cardoso Da Mata 
- João Victor Mnedes
- Matheus Silva De Carvalho
- Pedro Costa de Carvalho

## BrainStorm
``` 
Tema: anuncios de roupa.

Página Inicial(Apresentação)

Cadastrar login
Login
Minha conta(Alterar login)

Tela com os anuncios
Tela de anuncio mais detelhado

Meus anúncios
Tela de anuncios favoritados
Alterar anuncio
Inativar anuncio
Excluir anuncio
Tela anunciar

O usuario podera pesquisar anuncios mais especificos usando a barra de pesquisa.
Filtrar anuncios por estado.
Filtrar por genero.
Filtrar por tamanho.
Filtrar por condição.
````
## Links De Acesso

 [Link Trello](https://trello.com/b/yfaiP9p1/tcc-sistema-de-anuncios)
 
 [Link GitHub](
https://github.com/JVZer0/TCC)




## Casos de Uso ##

![Meus Anuncios](https://i.imgur.com/krToJfc.png)"

> 01. O Usuario podera Adicionar seus Anuncios , mandando seus dados .
> 02. O Usuario podera Visualizar seus Anuncios e de Outros usuario .
> 03. O Usuario podera Alterar , Editar seus Anuncios , Caso esteja Errado o deseja ser Atualizado.
> 04. O Usuario podera Deletar seus Anuncios , ==Caso não queira anunciar mais seu Produto==.
> 05. O Usuario tera o direito de inativar seus Anuncios ou seja, deixar ele ==Invisivel para outros usuarios .==

![Cadastrar](https://i.imgur.com/yHpwPGV.png)

> 01. Para o Usuario ter acesso ao Seu perfil , devera fazer o login.
> 02. Para que ele fiuque com uma conta no Sistema ele devera Cadastrar seu login.
> 03 . Caso o usuario queira mudar , alguma informação sobre ele , podera aterar seu login.



![Anuncios](https://i.imgur.com/v8cwHIo.png)


> 01. Voce Podera ver Seus Anuncios , conferi-los .
    >>01.1 Podendo filtrar por Genero , para uma ==facil Localização , de seu anuncio.==
    >>01.2 Podendo filtrar por tamanho , Caso seja Algo ja Definido.
    >>01.3 A barra de Pesquisa , Para uma pesquisa rapida ==, e precisa , caso esteja com pressa :laughing:==

---
---

## Excel Class

[Excel Github](https://github.com/JVZer0/TCC/blob/master/Analise/Excel/ExcelTCC.xlsx)

## Documentação PDF

[Documentação Via GitHub](https://github.com/JVZer0/TCC/tree/master/Analise/Documenta%C3%A7%C3%A3o)

## Prototipação 

![WireFrame Balsamiq](https://i.imgur.com/P3CixLl.png)

[Prototipação Detalhada via GitHub](https://github.com/JVZer0/TCC/blob/master/Analise/Prototipa%C3%A7%C3%A3o/Prototipacao.bmpr)

## Modelagem MER

![dbDesign](https://i.imgur.com/rkbcpbM.png)


## Scrip SQL(Terminal AWS)

``` Sql=

create database anuncioRoupa;

use anuncioRoupa;

create table tb_login(id_login int primary key auto_increment, ds_username varchar(255) not null, ds_senha varchar(255) not null);

create table tb_usuario(id_usuario int primary key auto_increment, nm_usuario varchar(255), dt_nascimento datetime, ds_sexo varchar(50), ds_cpf varchar(50), ds_rg varchar(50), ds_email varchar(255), ds_celular varchar(50), ds_estado varchar(50), ds_cidade varchar(130), ds_cep varchar(50), ds_endereco varchar(255), ds_bairro varchar(255), ds_n_endereco varchar(50), ds_complemento_endereco varchar(255), bt_concordo_termos bool, id_login int, foreign key (id_login) references tb_login(id_login) on delete cascade);

create table tb_anuncio(id_anuncio int primary key auto_increment, ds_titulo varchar(255),ds_descricao varchar(255), tp_produto varchar(255), ds_condicao varchar(255), ds_genero varchar(60), nm_marca varchar(255), ds_tamanho varchar(50), vl_preco decimal(15,2), ds_estado varchar(50), ds_cidade varchar(130), ds_cep varchar(50), bt_vendido bool, ds_situacao varchar(255), dt_publicacao datetime,id_usuario int,foreign key (id_usuario) references tb_usuario(id_usuario));

create table tb_imagem(id_imagem int primary key auto_increment,img_anuncio varchar(255),id_anuncio int,foreign key (id_anuncio) references tb_anuncio(id_anuncio));

create table tb_favorito(id_favorito int primary key auto_increment, bt_favorito bool, id_usuario int, id_anuncio int, foreign key (id_usuario) references tb_usuario(id_usuario), foreign key (id_anuncio) references tb_anuncio(id_anuncio));

create table tb_pergunta_resposta(id_pergunta_resposta int primary key auto_increment, ds_pergunta varchar(255), dt_pergunta datetime, bt_respondida bool, ds_resposta varchar(255), id_anuncio int, id_perguntador int, id_respondedor int, foreign key (id_anuncio) references tb_anuncio(id_anuncio), foreign key (id_perguntador) references tb_usuario(id_usuario));





insert into tb_login(ds_username, ds_senha) values('admin','1234');
insert into tb_login(ds_username, ds_senha) values('IanHV','FHPutWujpe');
insert into tb_login(ds_username, ds_senha) values('Lamorte','1234La');
insert into tb_login(ds_username, ds_senha) values('DeanW','1234super');




              
insert into tb_usuario(nm_usuario, dt_nascimento, ds_sexo, ds_cpf, ds_rg, ds_email, ds_celular, ds_estado, ds_cidade, ds_cep, ds_endereco, ds_bairro, ds_n_endereco, ds_complemento_endereco, bt_concordo_termos, id_login) values('Ian Heitor Vieira','1946-11-19','Masculino','730.736.610-00','14.228.859-7','ianheitorvieira__ianheitorvieira@pibnet.com.br','(51) 99765-5038', 'RS', 'Porto Alegre','90640-002','Rua Vicente da Fontoura','Rio Branco','284','',true,1);

insert into tb_usuario(nm_usuario, dt_nascimento, ds_sexo, ds_cpf, ds_rg, ds_email, ds_celular, ds_estado, ds_cidade, ds_cep, ds_endereco, ds_bairro, ds_n_endereco, ds_complemento_endereco, bt_concordo_termos, id_login) values('Paulo Fábio Ferreira','1972-10-14','Masculino','692.843.165-29','13.624.425-7','ppaulofabioferreira@pelozo.com.br','(68) 98215-6571', 'AC', 'Rio Branco','69915-314','Rua C','Conjunto Habitacional Vila Betel 2','150','',true,2);

insert into tb_usuario(nm_usuario, dt_nascimento, ds_sexo, ds_cpf, ds_rg, ds_email, ds_celular, ds_estado, ds_cidade, ds_cep, ds_endereco, ds_bairro, ds_n_endereco, ds_complemento_endereco, bt_concordo_termos, id_login) values('Sophia Lara Antônia Almeida','1953-05-21','Feminino','608.726.034-07','48.846.719-6','sophialaraantoniaalmeida-72@thibe.com.br','(81) 99273-0238', 'PE', 'Igarassu','53625-213','2ª Travessa Jacob Pinto de Freitas','Cruz do Rebouças','523','',true,3);

insert into tb_usuario(nm_usuario, dt_nascimento, ds_sexo, ds_cpf, ds_rg, ds_email, ds_celular, ds_estado, ds_cidade, ds_cep, ds_endereco, ds_bairro, ds_n_endereco, ds_complemento_endereco, bt_concordo_termos, id_login) values('José Cauã Nogueira','2002-05-12','Masculino','062.491.408-91','21.588.358-5','josecauanogueira-87@avantii.com.br','(92) 98783-4441', 'AM', 'Manaus','69090-799','Rua Doutor Solon Pinheiro','Cidade Nova','423','',true,4);





                
insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario) values('bermuda obey camuflada','bermuda tamanho m obey camuflada, vai na altura do joelho um pouco pra cima','Bermuda','Usado','Masculino','obey','M',149.00, 'PE'	, 'Recife', '90640-002',false,'Publicado','2020-09-25',1);

insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario) values('moletom amarelo nike','moletom tamanho m da nike ediçao especial track field, pouco usado, ótimo estado', 'Moletom','Usado','Masculino','nike','M',189.00, 'MG', 'Belo Horizonte', '69915-314',false,'Publicado','2020-09-25',2); 
               
insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario) values('Tenis Nike','Tenis Nike 12 molas', 'Tênis','Usado','Unisex','Nike','38',728.00, 'SP', 'São Paulo','53625-213',false,'Publicado','2020-09-25',3);

insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario) values('bermuda bmw bordado masculino','bermuda bmw bordado masculino tamanhos: m, g, gg, xxl.diversas cores: segue fotos.', 'Bermuda','Novo','Masculino','Puma','Diversos',145.00, 'RS', 'Porto Alegre','53625-213',false,'Publicado','2020-09-25',3);

insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario) values('test01','teste desc01', 'Bermuda','Novo','Masculino','Puma','Diversos',145.00, 'RS', 'Porto Alegre','53625-213',false,'Publicado','2020-09-25',3);

insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario) values('test02','teste desc02', 'Bermuda','Novo','Masculino','Puma','Diversos',145.00, 'RS', 'Porto Alegre','53625-213',false,'Publicado','2020-09-25',3);

insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario) values('test03','teste desc03', 'Bermuda','Novo','Masculino','Puma','Diversos',145.00, 'RS', 'Porto Alegre','53625-213',false,'Publicado','2020-09-25',3);

insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario) values('test04','teste desc04', 'Bermuda','Novo','Masculino','Puma','Diversos',145.00, 'RS', 'Porto Alegre','53625-213',false,'Publicado','2020-09-25',3);

insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario) values('test05','teste desc05', 'Bermuda','Novo','Masculino','Puma','Diversos',145.00, 'RS', 'Porto Alegre','53625-213',false,'Publicado','2020-09-25',3);



                
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',1);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',1);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',1);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',2);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',3);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',4);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',4);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',5);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',6);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',6);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',7);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',8);
insert into tb_imagem(img_anuncio, id_anuncio) values('semimagem.png',9);





               
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio) values(true,1,1);
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio) values(true,1,3);
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio) values(true,3,2);
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio) values(true,3,4);



                  
insert into tb_pergunta_resposta(ds_pergunta, dt_pergunta, bt_respondida, ds_resposta, id_perguntador, 	id_anuncio, id_respondedor) values('Oi, tudo bem? É original?','2020-10-16',true,'Sim é original.',3,4,3);
insert into tb_pergunta_resposta(ds_pergunta, dt_pergunta, bt_respondida, ds_resposta, id_perguntador, 	id_anuncio, id_respondedor) values('Ainda disponivel?','2020-10-16',true,'Sim',3,4,3);
insert into tb_pergunta_resposta(ds_pergunta, dt_pergunta, bt_respondida, ds_resposta, id_perguntador, 	id_anuncio, id_respondedor) values('Tem mais de uma peça?','2020-10-16',true,'Não',3,4,3);
insert into tb_pergunta_resposta(ds_pergunta, dt_pergunta, bt_respondida, ds_resposta, id_perguntador, 	id_anuncio, id_respondedor) values('Oi, tudo bem? É original?','2020-10-16',false,null,3,4,3);


select * from tb_login;
select * from tb_usuario;
select * from tb_anuncio;
select * from tb_imagem;
select * from tb_favorito;
select * from tb_pergunta_resposta;
```
## Scrip SQL Sistema de Anuncios

```sql=
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
    ds_estado				varchar(50),
    ds_cidade				varchar(130),
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

create table tb_pergunta_resposta(
	id_pergunta_resposta		int primary key auto_increment,
    ds_pergunta				varchar(255),
	dt_pergunta				datetime,
    bt_respondida			bool,
    ds_resposta				varchar(255),
    id_anuncio				int,
    id_perguntador			int,
    id_respondedor			int,
    foreign key (id_anuncio) references tb_anuncio(id_anuncio),
    foreign key (id_perguntador) references tb_usuario(id_usuario)
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
                
insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario)
				values('bermuda obey camuflada','bermuda tamanho m obey camuflada, vai na altura do joelho um pouco pra cima','Bermuda','Usado','Masculino','obey','M',149.00, 'PE'	, 'Recife', '90640-002',false,'Publicado','2020-09-25',1);
insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario)
				values('moletom amarelo nike','moletom tamanho m da nike ediçao especial track field, pouco usado, ótimo estado', 'Moletom','Usado','Masculino','nike','M',189.00, 'MG', 'Belo Horizonte', '69915-314',false,'Publicado','2020-09-25',2);                
insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario)
				values('Tenis Nike','Tenis Nike 12 molas', 'Tênis','Usado','Unisex','Nike','38',728.00, 'SP', 'São Paulo','53625-213',false,'Publicado','2020-09-25',3);
insert into tb_anuncio(ds_titulo, ds_descricao, tp_produto, ds_condicao, ds_genero, nm_marca, ds_tamanho, vl_preco, ds_estado, ds_cidade, ds_cep, bt_vendido, ds_situacao, dt_publicacao, id_usuario)
				values('bermuda bmw bordado masculino','bermuda bmw bordado masculino tamanhos: m, g, gg, xxl.diversas cores: segue fotos.', 'Bermuda','Novo','Masculino','Puma','Diversos',145.00, 'RS', 'Porto Alegre','53625-213',false,'Publicado','2020-09-25',3);
                
insert into tb_imagem(img_anuncio, id_anuncio)
			   values('semimagem.png',1);
insert into tb_imagem(img_anuncio, id_anuncio)
			   values('semimagem.png',1);
insert into tb_imagem(img_anuncio, id_anuncio)
			   values('semimagem.png',1);
insert into tb_imagem(img_anuncio, id_anuncio)
			   values('semimagem.png',2);
insert into tb_imagem(img_anuncio, id_anuncio)
			   values('semimagem.png',3);
insert into tb_imagem(img_anuncio, id_anuncio)
			   values('semimagem.png',4);
               
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio)
				  values(true,1,1);
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio)
				  values(true,1,3);
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio)
				  values(true,3,2);
insert into tb_favorito(bt_favorito, id_usuario, id_anuncio)
				  values(true,3,4);
                  
insert into tb_pergunta_resposta(ds_pergunta, dt_pergunta, bt_respondida, ds_resposta, id_perguntador, 	id_anuncio, id_respondedor)
						  values('Oi, tudo bem? É original?','2020-10-16',true,'Sim é original.',3,4,3);
insert into tb_pergunta_resposta(ds_pergunta, dt_pergunta, bt_respondida, ds_resposta, id_perguntador, 	id_anuncio, id_respondedor)
						  values('Ainda disponivel?','2020-10-16',true,'Sim',3,4,3);
insert into tb_pergunta_resposta(ds_pergunta, dt_pergunta, bt_respondida, ds_resposta, id_perguntador, 	id_anuncio, id_respondedor)
						  values('Tem mais de uma peça?','2020-10-16',true,'Não',3,4,3);
insert into tb_pergunta_resposta(ds_pergunta, dt_pergunta, bt_respondida, ds_resposta, id_perguntador, 	id_anuncio, id_respondedor)
						  values('Oi, tudo bem? É original?','2020-10-16',false,null,3,4,3);
               
               
select * from tb_login;
select * from tb_usuario;
select * from tb_anuncio;
select * from tb_imagem;
select * from tb_favorito;
select * from tb_pergunta_resposta;


select * from tb_favorito f join tb_anuncio a on f.id_anuncio = a.id_anuncio join tb_usuario u on f.id_usuario = u.id_usuario where nm_usuario like "%Sophia%";

select a.id_anuncio, a.ds_titulo, a.ds_descricao, a.tp_produto, a.ds_condicao, a.ds_genero, a.nm_marca, a.ds_tamanho, a.vl_preco, a.ds_cep, a.bt_vendido, a.ds_situacao, a.dt_publicacao, a.ds_estado, i.img_anuncio
from tb_anuncio a join tb_imagem i on a.id_anuncio = i.id_anuncio
where ds_descricao like '%%' and ds_estado like '%%' and ds_tamanho like '%%' and ds_genero like '%%' and ds_condicao like '%%';

select a.id_anuncio, a.ds_titulo, a.ds_descricao, a.tp_produto, a.ds_condicao, a.ds_genero, a.nm_marca, a.ds_tamanho, a.vl_preco, a.ds_cep, a.bt_vendido, a.ds_situacao, a.dt_publicacao, a.ds_estado, a.ds_cidade, i.img_anuncio
from tb_anuncio a join tb_imagem i on a.id_anuncio = i.id_anuncio join tb_usuario u on a.id_usuario = u.id_usuario
where ds_descricao like '%%' and a.ds_estado like '%%' and a.ds_tamanho like '%%' and a.ds_genero like '%%' and a.ds_condicao like '%%';
```

## Rotas API
```
Get "Anuncio/{BarraPesquisa}/{Estado}/{Cidade}/{Genero}/{Condicao}" = Consultar Anuncios

Get "Anuncio/AnuncioDetalhado/{IdAnuncio}" = Consultar Anuncio Detalhado

Post "Anuncio/Perguntar" = Perguntar

Put "Anuncio/Responder" = Responder

Post "Anuncio/Anunciar" = Anunciar

Get "Anuncio/MeusAnuncios/{IdUsuario}" = ConsultarMeusAnuncios

Delete "Anuncio/DeletarAnuncio/{IdAnuncio}/{IdUsuario}" = Deletar Anuncio

Put "Anuncio/InativarAnuncio/{IdAnuncio}" = Inativar Anuncio

Put "Anuncio/AnuncioVendido/{IdAnuncio}" = Anuncio Vendido

Put "Anuncio/AlterarAnuncio" = Alterar Anuncio

Put "Anuncio/AtivarAnuncio/{IdAnuncio}" = Ativar Anuncio



Get "Favorito/Favorito/{IdAnuncio}/{IdUsuario}" = Consultar Se O Anuncio Esta Favoritado

Get "Favorito/MeusFavoritos/{IdUsuario}" = Consultar Meus Favoritos

Post "Favorito/FavoritarAnuncio/{IdAnuncio}/{IdUsuario}" = Favoritar Anuncio

Delete "Favorito/DeletarFavorito/{IdAnuncio}/{IdUsuario}" = Deletar Favorito



Delete "Imagem/{IdImagem}/{IdAnuncio}" = Excluir Imagem

Post "Imagem/{IdAnuncio}" = Adicionar Imagem

Get "Imagem/BuscarImagem/{nome}" = Buscar Imagem

Post "Imagem/AdicionarVariasImagens/{IdAnuncio}" = Adicionar Varias Imagem



Post "Login/" = Logar

Post "Login/Criarlogin" = Cadastrar Login



Get "Relatorios/AnunciosPorDia" = AnunciosPorDia

Get "Relatorios/AnunciosPorMes" = AnunciosPorMes

Get "Relatorios/Top10Clientes" = Top10Clientes

Get "Relatorios/Top10Produtos" = Top10Produtos



Put "Usuario/" = Alterar

Get "Usuario/{IdUsuario}" = Consultar Infomacoes Do Usuario

Post "Usuario/RecuperarSenha" = RecuperarSenha
```

---
