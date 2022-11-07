create database dbTestDrive;
use dbTestDrive;

show tables;

create table tb_nivel_acesso(
	id_nivel_acesso int primary key auto_increment,
    ds_nivel varchar(100) not null
);

create table tb_usuario(
	id_usuario int primary key auto_increment,
    nm_usuario varchar(100) not null,
    ds_email varchar(100) not null,
    ds_senha varchar(30) not null,
    dt_nascimento datetime not null,
    dt_ultimo_login datetime not null,
    dt_conta_criada datetime not null,
    dt_conta_atualizada datetime not null,
    id_nivel_acesso int,
    
    foreign key (id_nivel_acesso) references tb_nivel_acesso (id_nivel_acesso)
);

create table tb_clientes(
	id_cliente int primary key auto_increment,
    nm_cliente varchar(100) not null,
    ds_endereco varchar(100) not null,
    nr_rg varchar(20) not null,
    nr_cpf varchar(20) not null,
    nr_cnh varchar(30) not null,
    nr_telefone varchar(20),
    nr_celular varchar(20),
    id_usuario int,
    
    foreign key (id_usuario) references tb_usuario (id_usuario)
);

create table tb_combustivel(
	id_combustivel int primary key auto_increment,
    ds_combustivel varchar(100)
);

create table tb_cambio(
	id_cambio int primary key auto_increment,
    ds_cambio varchar(45)
);

create table tb_fabricante(
	id_fabricante int primary key auto_increment,
    ds_fabricante varchar(100)
);

create table tb_modelo(
	id_modelo int primary key auto_increment,
    ds_modelo varchar(100)
);

create table tb_carros(
	id_carro int primary key auto_increment,
    nm_carro varchar(150) not null,
    dt_ano_fabricacao datetime not null,
    dt_ano_modelo datetime not null,
    ds_potencia varchar(100) not null,
    vl_preco decimal(15,2) not null,
    id_modelo int,
    id_fabricante int,
    id_cambio int,
    id_combustivel int,
    
    foreign key (id_modelo) references tb_modelo (id_modelo),
    foreign key (id_fabricante) references tb_fabricante (id_fabricante),
    foreign key (id_cambio) references tb_cambio (id_cambio),
    foreign key (id_combustivel) references tb_combustivel (id_combustivel)
);

create table tb_test_drive(
	id_test_drive int primary key auto_increment,
    dt_test_drive datetime not null,
    bl_desmarcado bool not null,
    bl_realizado bool not null,
	id_cliente int,
    id_carro int,
    
    foreign key (id_cliente) references tb_clientes (id_cliente),
    foreign key (id_carro) references tb_carros (id_carro)
);

create table tb_avaliacao(
	id_avaliacao int primary key auto_increment,
    vl_feedback decimal (15,2)
);

create table tb_feedback(
	id_feedback int primary key auto_increment,
    ds_feedback varchar(500) not null,
    dt_feedback datetime not null,
    dt_ultima_alteracao datetime not null,
    id_avaliacao int,
    id_usuario int,
    
    foreign key (id_avaliacao) references tb_avaliacao (id_avaliacao),
    foreign key (id_usuario) references tb_usuario (id_usuario)
);
