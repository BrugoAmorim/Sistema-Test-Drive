
use dbTestDrive;
select * from tb_carros;

-- Registros tb_carros

/* Conversíveis */

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Aventador SVJ Roadster", '2021-01-01', '2022-01-01', "1.98 kg/cv", 100000.00, 1, 2, 1, 1);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Mclaren 720S Spider", '2021-01-01', '2022-01-01', "1.90 kg/cv", 82000.00, 1, 2, 2, 1);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Cooper S Cabrio Sport", '2022-01-01', '2023-01-01', "6.90 kg/cv", 1800.00, 1, 2, 3, 1);

/* Sedã */

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Honda City", '2020-01-01', '2021-01-01', "9,78 kg/cv", 11000.00, 2, 2, 4, 2);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Fiat Grand Siena", '2021-01-01', '2022-01-01', "12.43 kg/cv", 8200.00, 2, 1, 5, 2);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Hyundai HB20S", '2021-01-01', '2022-01-01', "8.12 kg/cv", 7400.00, 2, 1, 6, 2);

/* Hatch */

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Volkswagen Polo", '2021-01-01', '2022-01-01', "8.96 kg/cv", 7400.00, 3, 2, 7, 2);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Chevrolet Onix Hatch", '2023-01-01', '2024-01-01', "9.18 kg/cv", 12800.00, 3, 1, 8, 2);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Ford Ka Hatch", '2021-01-01', '2022-01-01', "12.26 kg/cv", 9130.00, 3, 1, 9, 2);

/* Cupê */

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Mercedes-benz glc", '2019-01-01', '2020-01-01', "8.22 kg/cv", 31100.00, 4, 2, 10, 2);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Chevrolet camaro 6.2", '2022-01-01', '2023-01-01', "3.71 kg/cv", 54000.00, 4, 2, 8, 1);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Mitsubishi eclipse 3.8", '2008-01-01', '2020-01-01', "8.22 kg/cv", 12650.00, 4, 1, 11, 1);

/* Veículo Utilitário Esportivo  */

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Volkswagen Saveiro", '2022-01-01', '2023-01-01', "9.81 kg/cv", 19300.00, 6, 1, 7, 2);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Chevrolet Montana", '2021-01-01', '2022-01-01', "11.08 kg/cv", 21120.00, 6, 1, 8, 2);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Peugeot Partner", '2022-01-01', '2023-01-01', "9.33 kg/cv", 25800.00, 6, 1, 12, 2);

/* Picape */

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Chevrolet S10 LTZ 2.8", '2022-01-01', '2023-01-01', "10.21 kg/cv", 48800.00, 7, 2, 8, 3);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Chevrolet Trailblazer.", '2022-01-01', '2023-01-01', "10.81 kg/cv", 62700.00, 7, 2, 8, 3);

insert into tb_carros(nm_carro, dt_ano_fabricacao, dt_ano_modelo, ds_potencia, vl_preco, id_modelo, id_cambio, id_fabricante, id_combustivel)
values("Fiat Fiorino", '2021-01-01', '2023-01-01', "12.70 kg/cv", 17900.00, 7, 1, 5, 2);
