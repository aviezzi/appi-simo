CREATE DATABASE "KingRoger";

\connect "KingRoger";

create table "Lights"
(
    "Id" uuid not null constraint "PK_Lights" primary key,
    "LightType" text,
    "Price" numeric not null,
    "Enabled" boolean not null

);

alter table "Lights" owner to "RobotBoy";

create table "Heats"
(
    "Id" uuid not null constraint "PK_Heats" primary key,
    "HeatType" text,
    "Price" numeric not null,
    "Enabled" boolean not null

);

alter table "Heats" owner to "RobotBoy";

create table "Courts"
(
    "Id" uuid not null constraint "PK_Courts" primary key,
    "Name" text,
    "LightId" uuid not null constraint "FK_Courts_Lights_LightId" references "Lights" on delete cascade,
    "HeatId" uuid not null constraint "FK_Courts_Heats_HeatId" references "Heats" on delete cascade,
    "Enabled" boolean not null
);

alter table "Courts" owner to "RobotBoy";

create index "IX_Courts_LightId" on "Courts" ("LightId");
create index "IX_Courts_HeatId" on "Courts" ("HeatId");

create table "Rates"
(
    "Id" uuid not null constraint "PK_Rates" primary key,
    "Name" text,
    "Start" date,
    "End" date
);

alter table "Rates" owner to "RobotBoy";

create table "DailyRates"
(
    "Id" uuid not null constraint "PK_DailyRates" primary key,
    "Start" time not null,
    "End" time not null,
    "Price" numeric not null,
    "RateId" uuid not null constraint "FK_Rates_DailyRates_RateId" references "Rates" on delete cascade
);

alter table "DailyRates" owner to "RobotBoy";
