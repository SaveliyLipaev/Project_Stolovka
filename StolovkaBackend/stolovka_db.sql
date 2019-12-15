CREATE TABLE "users" (
  "id" int PRIMARY KEY,
  "first_name" varchar(65),
  "last_name" varchar(65),
  "token" varchar UNIQUE NOT NULL,
  "email" varchar UNIQUE NOT NULL,
  "card" varchar
);

CREATE TABLE "canteens" (
  "id" int PRIMARY KEY,
  "name" varchar(255) NOT NULL,
  "address" varchar(255) NOT NULL,
  "worktime" varchar(30) NOT NULL
);

CREATE TABLE "dishs" (
  "id" int PRIMARY KEY,
  "name" varchar(65) NOT NULL,
  "price" int NOT NULL,
  "canteen_id" int NOT NULL
);

CREATE TABLE "cashiers" (
  "id" int PRIMARY KEY,
  "login" varchar(65) UNIQUE NOT NULL,
  "hash_password" varchar NOT NULL,
  "canteen_id" int NOT NULL,
  "status" varchar NOT NULL
);

ALTER TABLE "dishs" ADD FOREIGN KEY ("canteen_id") REFERENCES "canteens" ("id");

ALTER TABLE "cashiers" ADD FOREIGN KEY ("canteen_id") REFERENCES "canteens" ("id");
