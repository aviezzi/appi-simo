CREATE DATABASE "KingRoger";

\connect "KingRoger";

create table "Lights"
(
    "Id" uuid not null
        constraint "PK_Lights"
            primary key,
    "LightType" text,
    "Price" numeric not null
);

alter table "Lights" owner to "RobotBoy";

