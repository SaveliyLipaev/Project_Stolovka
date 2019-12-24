CREATE TABLE "users" (
  "id" varchar(255) PRIMARY KEY NOT NULL,
  "firstname" varchar(65),
  "lastname" varchar(65),
  "token" varchar UNIQUE NOT NULL,
  "email" varchar UNIQUE NOT NULL,
  "card" varchar
);

CREATE TABLE "canteens" (
  "id" varchar(255) PRIMARY KEY NOT NULL,
  "name" varchar(255) NOT NULL,
  "address" varchar(255) NOT NULL,
  "worktime" varchar(30) NOT NULL
);

CREATE TABLE "dishes" (
  "dish_id" varchar(255) PRIMARY KEY NOT NULL,
  "dish_name" varchar(65) NOT NULL,
  "dish_price" decimal NOT NULL,
  "canteen_id" varchar NOT NULL
);

CREATE TABLE "cashiers" (
  "id" varchar(255) PRIMARY KEY NOT NULL,
  "login" varchar(65) UNIQUE NOT NULL,
  "password_crypted" varchar NOT NULL,
  "canteen_id" varchar NOT NULL,
  "role" varchar NOT NULL
);

CREATE TABLE "cards" (
  "card_number_crypted" varchar(255) PRIMARY KEY NOT NULL,
  "recognizeable_name" varchar,
  "added_at" timestamp NOT NULL
);

CREATE TABLE "orders" (
  "order_id" varchar(255) PRIMARY KEY NOT NULL,
  "user_id" varchar(255) NOT NULL,
  "canteen_id" varchar(255) NOT NULL,
  "status" varchar NOT NULL,
  "created_at" timestamp NOT NULL,
  "processed_at" timestamp,
  "description" varchar NOT NULL
);

ALTER TABLE "users" ADD FOREIGN KEY ("card") REFERENCES "cards" ("card_number_crypted");

ALTER TABLE "dishes" ADD FOREIGN KEY ("canteen_id") REFERENCES "canteens" ("id");

ALTER TABLE "cashiers" ADD FOREIGN KEY ("canteen_id") REFERENCES "canteens" ("id");

ALTER TABLE "orders" ADD FOREIGN KEY ("user_id") REFERENCES "users" ("id");

ALTER TABLE "orders" ADD FOREIGN KEY ("canteen_id") REFERENCES "canteens" ("id");
