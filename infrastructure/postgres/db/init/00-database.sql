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