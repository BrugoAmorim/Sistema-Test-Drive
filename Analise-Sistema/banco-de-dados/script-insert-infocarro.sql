
use dbTestDrive;

select * from tb_cambio;
select * from tb_modelo;
select * from tb_combustivel;
select * from tb_fabricante;

-- Registros tb_cambio

insert into tb_cambio(ds_cambio)
values("Câmbio manual");

insert into tb_cambio(ds_cambio)
values("Câmbio automático");

insert into tb_cambio(ds_cambio)
values("Câmbio automático sequencial");

-- Registros tb_modelo

insert into tb_modelo(ds_modelo)
values("Conversível");

insert into tb_modelo(ds_modelo)
values("Sedã");

insert into tb_modelo(ds_modelo)
values("hatch");

insert into tb_modelo(ds_modelo)
values("Cupê");

insert into tb_modelo(ds_modelo)
values("Perua");

insert into tb_modelo(ds_modelo)
values("Veículo Utilitário Esportivo");

insert into tb_modelo(ds_modelo)
values("Picape");

insert into tb_modelo(ds_modelo)
values("Minivan");

-- Registros tb_fabricante

insert into tb_fabricante(ds_fabricante)
values("Lamborghini, Grupo Volkswagen");

insert into tb_fabricante(ds_fabricante)
values("McLaren Automotive");

insert into tb_fabricante(ds_fabricante)
values("BMW");

insert into tb_fabricante(ds_fabricante)
values("Honda");

insert into tb_fabricante(ds_fabricante)
values("Fiat");

insert into tb_fabricante(ds_fabricante)
values("Hyundai Motor Company");

insert into tb_fabricante(ds_fabricante)
values("Volkswagen");

insert into tb_fabricante(ds_fabricante)
values("Chevrolet");

insert into tb_fabricante(ds_fabricante)
values("Ford");

insert into tb_fabricante(ds_fabricante)
values("Mercedes-Benz");

insert into tb_fabricante(ds_fabricante)
values("Mitsubishi");

insert into tb_fabricante(ds_fabricante)
values("Peugeot");

-- Registros tb_combustivel

insert into tb_combustivel(ds_combustivel)
values("Gasolina");

insert into tb_combustivel(ds_combustivel)
values("Flex (álcool/gasolina)");

insert into tb_combustivel(ds_combustivel)
values("Diesel");