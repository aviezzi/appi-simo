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

create table "CourtRates"
(
    "RateId" uuid not null constraint "FK_CourtRate_Rate_RateId" references "Rates",
    "CourtId" uuid not null constraint "FK_CourtRate_Court_CourtId" references "Courts"
,    "Date" timestamp 
);

alter table "CourtRates" owner to "RobotBoy";

create table "Profiles"
(
    "Id" uuid not null constraint "PK_Profiles" primary key,
    "Name" text not null,
    "Surname" text not null,
    "Gender" text not null,
    "Address" text not null,
    "Email" text not null,
    "Birthdate" date not null,
    "Phone" text, 
    "Sub" uuid not null
);

comment on table "Profiles" is E'@foreignKey ("Id") references "vDebts" ("Id")';
alter table "Profiles" owner to "RobotBoy";

create table "Events"
(
    "Id" uuid not null constraint "PK_Events" primary key,
    "StartDate" timestamp not null,
    "EndDate" timestamp not null,
    "LightId" uuid constraint "FK_Event_Light_LightId" references "Lights",
    "HeadId" uuid constraint "FK_Event_Heat_HeatId" references "Heats",
    "CourtId" uuid not null constraint "FK_Event_Court_CourtId" references "Courts",
    "LightDuration" numeric(1,0) constraint "Max_LightDuration_Value" check ("LightDuration" <= 1 and "LightDuration" >= 0),
    "HeatDuration" numeric(1,0) constraint "Max_HeatDuration_Value" check ("HeatDuration" <= 1 and "HeatDuration" >= 0)
);

alter table "Events" owner to "RobotBoy";

create table "ProfileEvents"
(
    "Id" uuid not null constraint "PK_ProfileEvents" primary key,
    "ProfileId" uuid not null constraint "FK_ProfileEvents_Profile_ProfileId" references "Profiles",
    "EventId" uuid not null constraint "FK_ProfileEvents_Event_EventId" references "Events",
    "Price" money not null,
    "Paid" boolean not null default false
);

alter table "ProfileEvents" owner to "RobotBoy";

create view "vDebts" as
select p."Id", sum(pe."Price") as "Debt"
from "Profiles" p
         join "ProfileEvents" pe on p."Id" = pe."ProfileId"
         join "Events" e on pe."EventId" = e."Id"
where pe."Paid" = false
group by p."Id", p."Name", p."Surname";

alter view "vDebts" owner to "RobotBoy";