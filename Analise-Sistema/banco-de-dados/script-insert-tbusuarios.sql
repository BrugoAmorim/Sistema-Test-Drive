
use dbTestDrive;
select * from tb_usuario;
select * from tb_nivel_acesso;

-- Registros tb_nivel_acesso

insert into tb_nivel_acesso(ds_nivel)
values("Gerente");

insert into tb_nivel_acesso(ds_nivel)
values("Cliente");

-- Registros tb_usuario

insert into tb_usuario(nm_usuario, ds_email, ds_senha, dt_nascimento, dt_ultimo_login, dt_conta_criada, dt_conta_atualizada, id_nivel_acesso)
values("Bruno Gomes", "bruno.gomes@gmail.com", '12345678',  '2004-11-01', '2022-02-10', '2022-01-01', '2022-01-01', 1);

insert into tb_usuario(nm_usuario, ds_email, ds_senha, dt_nascimento, dt_ultimo_login, dt_conta_criada, dt_conta_atualizada, id_nivel_acesso)
values("Felipe Ramos", "felipeh2022@gmail.com", 'cavalo12',  '2001-08-01', '2022-04-12', '2022-01-21', '2022-02-11', 2);

insert into tb_usuario(nm_usuario, ds_email, ds_senha, dt_nascimento, dt_ultimo_login, dt_conta_criada, dt_conta_atualizada, id_nivel_acesso)
values("Giovanna Teixeira", "gigi.texeira@gmail.com", 'repolhorox0',  '2000-05-14', '2022-03-10', '2022-03-10', '2022-03-10', 2);

insert into tb_usuario(nm_usuario, ds_email, ds_senha, dt_nascimento, dt_ultimo_login, dt_conta_criada, dt_conta_atualizada, id_nivel_acesso)
values("Larissa Pereira", "lari_pereira@gmail.com", 'password',  '1998-04-01', '2022-01-27', '2022-01-29', '2022-01-29', 2);

insert into tb_usuario(nm_usuario, ds_email, ds_senha, dt_nascimento, dt_ultimo_login, dt_conta_criada, dt_conta_atualizada, id_nivel_acesso)
values("Gabriel Amorim", "GabrielGome5@gmail.com", '9876543210',  '2003-11-01', '2022-07-09', '2022-07-09', '2022-07-11', 2);