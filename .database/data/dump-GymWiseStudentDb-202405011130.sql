--
-- PostgreSQL database dump
--

-- Dumped from database version 15.4 (Debian 15.4-1.pgdg120+1)
-- Dumped by pg_dump version 15.3

-- Started on 2024-05-01 11:30:24

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 215 (class 1259 OID 90123)
-- Name: Student; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Student" (
    "Id" uuid NOT NULL,
    "FirstName" text NOT NULL,
    "LastName" text NOT NULL,
    "CellPhone" text NOT NULL,
    "DateOfBirth" timestamp without time zone NOT NULL,
    "Document" character varying(14) NOT NULL,
    "HeightInCentimeters" smallint,
    "WeightInKilograms" smallint,
    "Gender" integer,
    "Number" character varying(50),
    "City" character varying(100),
    "State" character varying(100),
    "Neighborhood" character varying(100),
    "ZipCode" character varying(8),
    "TrainingGoals" text,
    "MedicalRestrictionsorInjuries" text,
    "TrainingExperienceLevel" text,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "UpdatedOnUtc" timestamp without time zone,
    "IsDeleted" boolean DEFAULT false NOT NULL,
    "DeletedOnUtc" timestamp without time zone
);


ALTER TABLE public."Student" OWNER TO postgres;

--
-- TOC entry 3345 (class 0 OID 90123)
-- Dependencies: 215
-- Data for Name: Student; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Student" ("Id", "FirstName", "LastName", "CellPhone", "DateOfBirth", "Document", "HeightInCentimeters", "WeightInKilograms", "Gender", "Number", "City", "State", "Neighborhood", "ZipCode", "TrainingGoals", "MedicalRestrictionsorInjuries", "TrainingExperienceLevel", "CreatedOnUtc", "UpdatedOnUtc", "IsDeleted", "DeletedOnUtc") FROM stdin;
445c095e-2f3c-4ae8-ae67-95db6fefacff	John	Doe	55999398534	1995-04-23 17:27:03.232	03567314050	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	2024-04-23 17:28:10.606886	\N	f	\N
e01faa14-8548-4b3c-9dd1-d9c64ec2036a	Bruno	Amaral	55999999999	1995-05-01 14:09:35.412	29698027084	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	\N	2024-05-01 14:11:24.908349	\N	f	\N
\.


--
-- TOC entry 3202 (class 2606 OID 90130)
-- Name: Student PK_Student; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Student"
    ADD CONSTRAINT "PK_Student" PRIMARY KEY ("Id");


-- Completed on 2024-05-01 11:30:24

--
-- PostgreSQL database dump complete
--

