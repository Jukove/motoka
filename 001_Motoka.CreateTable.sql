CREATE TABLE vehicles (
    id SERIAL PRIMARY KEY,
    placa VARCHAR(8) NOT NULL  UNIQUE,
    modelo VARCHAR(15) NOT NULL,
    ano VARCHAR(6) NOT NULL,
    is_available BOOLEAN NOT NULL,
);

CREATE TABLE rent (
    id SERIAL PRIMARY KEY,
    start_date DATE NOT NULL,
    end_date DATE,
    vehicle_plate VARCHAR(10) NOT NULL,
    delivery_driver_cnpj VARCHAR(16) NOT NULL,
    total_cost NUMERIC NOT NULL,
    fine NUMERIC,
    range VARCHAR(14) NOT NULL,
    expected_date VARCHAR(14) NOT NULL,
    CONSTRAINT fk_vehicle_plate FOREIGN KEY (vehicle_plate) REFERENCES vehicle(placa),
    CONSTRAINT fk_delivery_driver_cnpj FOREIGN KEY (delivery_driver_cnpj) REFERENCES delivery_driver(cnpj)
);

CREATE TABLE order_notification (
    id SERIAL PRIMARY KEY,
    delivery_driver_cnpj VARCHAR(14) NOT NULL,
    sent_date TIMESTAMP NOT NULL,
    message TEXT,
    order_id INT NOT NULL,
    is_accept BOOLEAN NOT NULL,
    CONSTRAINT fk_ordernotifications_order FOREIGN KEY (order_id) REFERENCES orders(id),
    CONSTRAINT fk_ordernotifications_deliverydriver FOREIGN KEY (delivery_driver_cnpj) REFERENCES delivery_driver(cnpj)
);

CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    status VARCHAR(255) NOT NULL,
    creation_date TIMESTAMP NOT NULL,
    delivery_cost NUMERIC(10, 2) NOT NULL
);

CREATE TABLE delivery_driver (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    cnpj VARCHAR(14) NOT NULL UNIQUE,
    birth_date DATE NOT NULL,
    driver_license_number VARCHAR(20) NOT NULL,
    type_cnh VARCHAR(10) NOT NULL,
    image_name VARCHAR(10) NOT NULL UNIQUE
);