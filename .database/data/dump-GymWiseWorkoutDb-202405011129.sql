--
-- PostgreSQL database dump
--

-- Dumped from database version 15.4 (Debian 15.4-1.pgdg120+1)
-- Dumped by pg_dump version 15.3

-- Started on 2024-05-01 11:29:54

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
-- TOC entry 215 (class 1259 OID 90141)
-- Name: Exercise; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Exercise" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "UrlVideo" text,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "UpdatedOnUtc" timestamp without time zone,
    "IsDeleted" boolean DEFAULT false NOT NULL,
    "DeletedOnUtc" timestamp without time zone
);


ALTER TABLE public."Exercise" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 90170)
-- Name: Sets; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Sets" (
    "Id" uuid NOT NULL,
    "Reps" smallint NOT NULL,
    "Series" smallint NOT NULL,
    "IntervalsInSeconds" smallint,
    "Weight" smallint,
    "AdvancedTechnique" character varying(150),
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "UpdatedOnUtc" timestamp without time zone,
    "IsDeleted" boolean DEFAULT false NOT NULL,
    "DeletedOnUtc" timestamp without time zone,
    "ExerciseId" uuid NOT NULL,
    "WorkoutId" uuid
);


ALTER TABLE public."Sets" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 90157)
-- Name: Workout; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Workout" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "Type" integer,
    "Observations" text,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "UpdatedOnUtc" timestamp without time zone,
    "IsDeleted" boolean DEFAULT false NOT NULL,
    "DeletedOnUtc" timestamp without time zone,
    "WorkoutRoutineId" uuid NOT NULL
);


ALTER TABLE public."Workout" OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 90149)
-- Name: WorkoutRoutine; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."WorkoutRoutine" (
    "Id" uuid NOT NULL,
    "StudentId" uuid,
    "Title" character varying(100) NOT NULL,
    "Observations" text,
    "Active" boolean NOT NULL,
    "InactiveOnExpiration" boolean NOT NULL,
    "StartDate" timestamp without time zone,
    "ExpirationDate" timestamp without time zone,
    "CreatedOnUtc" timestamp without time zone NOT NULL,
    "UpdatedOnUtc" timestamp without time zone,
    "IsDeleted" boolean DEFAULT false NOT NULL,
    "DeletedOnUtc" timestamp without time zone
);


ALTER TABLE public."WorkoutRoutine" OWNER TO postgres;

--
-- TOC entry 3369 (class 0 OID 90141)
-- Dependencies: 215
-- Data for Name: Exercise; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Exercise" ("Id", "Name", "UrlVideo", "CreatedOnUtc", "UpdatedOnUtc", "IsDeleted", "DeletedOnUtc") FROM stdin;
03a390e3-36b3-4f3d-8965-6280ee531f66	Desenvolvimento Posterior	https://youtu.be/WIlm9oHEEq8	2024-04-23 20:32:48.253539	\N	f	\N
047c78ae-4dbd-4a78-a393-bbac00f60e04	Tríceps Pulley Corda	https://youtu.be/_KrR8248eLo	2024-04-23 20:32:48.253539	\N	f	\N
04c8e7cc-7e31-4dba-9dd7-7fcaa6297b39	Frontal Anilha	https://youtu.be/5bdlcZZvpzE	2024-04-23 20:32:48.253539	\N	f	\N
055076d1-b99b-48a6-96ac-d0af9f39fe7c	Flexão De Braço Fechada	https://youtu.be/9qT4QxmIuuU	2024-04-23 20:32:48.253539	\N	f	\N
067f0b32-32ed-4f56-b1e0-246e3a9ec5c6	Supino Fechado	https://youtu.be/qJGw6CnVh2Q	2024-04-23 20:32:48.253539	\N	f	\N
07cff5cf-8f73-416b-8609-2b99fa1d67de	Flexão De Braço	https://youtu.be/F9FC_KBsLpY	2024-04-23 20:32:48.253539	\N	f	\N
094dcf05-f6c3-467c-8ccb-649b8a64d743	Remada Alta Smith	https://youtu.be/lD_zvmzP1K0	2024-04-23 20:32:48.253539	\N	f	\N
1294b6e7-e00e-4f5f-8ad5-d512035b9292	Supino Inclinado Halteres	https://youtu.be/Z1rCZ0YHrP0	2024-04-23 20:32:48.253539	\N	f	\N
140dbd6b-041f-4301-9fac-640996e26ea3	Crucifixo Reto Halteres	https://youtu.be/dQi36EfA88c	2024-04-23 20:32:48.253539	\N	f	\N
144018f3-d2fc-40b9-810e-3efbcf75224f	Remada Unilateral PegSupinada	https://youtu.be/MAHNlcA4oXc	2024-04-23 20:32:48.253539	\N	f	\N
18254907-2c8b-41b2-b254-8bbbec1a1f75	Remada Cross PegPronada	https://youtu.be/IA0SRm2mY9M	2024-04-23 20:32:48.253539	\N	f	\N
1fd923a8-87ce-4eaa-bb88-c2f592be970f	Tríceps Pulley Unilateral PegPronada	https://youtu.be/TmO_85EK09I	2024-04-23 20:32:48.253539	\N	f	\N
2a22b107-c3ad-44dd-866c-1ed249c94307	Remada Alta Cross	https://youtu.be/dHjEyNaCmn0	2024-04-23 20:32:48.253539	\N	f	\N
30303280-7240-4f3e-8249-0f0c117ee250	Desenvolvimento Militar	https://youtu.be/urj7vgvfojk	2024-04-23 20:32:48.253539	\N	f	\N
323c673d-7dd1-48e5-b9a5-6b10475b075b	Encolhimento Smith Anterior	https://youtu.be/5DQl_71T8iI	2024-04-23 20:32:48.253539	\N	f	\N
349868ae-e2bb-45f2-9791-e6086bacaccc	Rosca Testa Barra PegSupinada	https://youtu.be/D_wnqWbIrYs	2024-04-23 20:32:48.253539	\N	f	\N
3f7b929c-da12-47e0-9f52-912f66d1c7c2	Levantamento Terra	https://youtu.be/T3x53s0jEns	2024-04-23 20:32:48.253539	\N	f	\N
40751d42-6b62-47d9-a498-7a0f010de834	Elevação Frontal Halteres Peg Neutra	https://youtu.be/kQTNDsaEIKc	2024-04-23 20:32:48.253539	\N	f	\N
42f1603e-aab5-4bd5-9a98-d852bd3db68e	Rosca Francesa Halteres PegPronada	https://youtu.be/DCbDClEDQvQ	2024-04-23 20:32:48.253539	\N	f	\N
42f805d9-7ddf-4cf8-b4c6-1a66ec2f5667	Elevação Frontal Cross PegSupinada	https://youtu.be/lL8hIRuFcnU	2024-04-23 20:32:48.253539	\N	f	\N
46367ffa-16ed-46ae-b003-13d964643cf9	Rosca Francesa Anilha	https://youtu.be/D2oQJTz	2024-04-23 20:32:48.253539	\N	f	\N
4bec1dc1-8d7e-4550-a59a-cc52f5a2b260	Supino Declinado Smith	https://youtu.be/xLQ9ZbH9ljc	2024-04-23 20:32:48.253539	\N	f	\N
50301e13-664e-4300-915d-eb50ae2cb127	Supino Reto Halteres	https://youtu.be/Spbmm66NsuY	2024-04-23 20:32:48.253539	\N	f	\N
537c661d-5980-46a5-9eef-104e2da65910	Puxada Vertical PegSupinada	https://youtu.be/v1rPzvJvwIE	2024-04-23 20:32:48.253539	\N	f	\N
54b8d26f-0ad0-4eb6-a9a8-75fb64c74eed	Pull-Down Cross Peg Pronada	https://youtu.be/EG1ua8lDQJA	2024-04-23 20:32:48.253539	\N	f	\N
5bddfb51-0dc6-4ac8-99db-3991714daf68	Barra Fixa PegPronada	https://youtu.be/JX_YM7Bp26U	2024-04-23 20:32:48.253539	\N	f	\N
5cd6e978-1b3c-4e7e-baa4-f7d2ee71161c	Encolhimento Barra Posterior	https://youtu.be/Y4w7ZZW84eM	2024-04-23 20:32:48.253539	\N	f	\N
5ebddaa4-035c-4d8f-82d2-0de81313a988	Over Polia Baixa	https://youtu.be/Jy_hZnK	2024-04-23 20:32:48.253539	\N	f	\N
62c7d6cb-26bd-433a-8490-5da8b60b23af	Supino Inclinado Smith	https://youtu.be/L4kIk2gMeBw	2024-04-23 20:32:48.253539	\N	f	\N
64b8669e-840a-4066-857b-34fe792a40a5	Remada Curvada Halteres Peg Neutra	https://youtu.be/CyCkDYs49hM	2024-04-23 20:32:48.253539	\N	f	\N
658e0409-ca0d-4c48-a7b6-82f750df3746	Encolhimento Smith Posterior	https://youtu.be/7Ui8zi1w5A4	2024-04-23 20:32:48.253539	\N	f	\N
66f12521-25d5-4d61-bacc-24a8d8a0c13b	Rosca Francesa Halteres Peg Neutra	https://youtu.be/aI8x4pHiByU	2024-04-23 20:32:48.253539	\N	f	\N
697874df-e934-41d5-a6be-995ef847e8a0	res Peg Neutra	https://youtu.be/KzKdkwIjZg8	2024-04-23 20:32:48.253539	\N	f	\N
6fcf3662-6ebd-4a92-b611-106f180c7714	Elevação Lateral Sentado Halteres	https://youtu.be/esWhjFJMNtU	2024-04-23 20:32:48.253539	\N	f	\N
706854c3-a679-4e44-ae58-8b9f54cf4b78	Remada Curvada Halteres PegSupinada	https://youtu.be/g0VduhIsJIE	2024-04-23 20:32:48.253539	\N	f	\N
79310f45-f607-425a-84de-96fb8c1b95bc	Elevação Frontal Halteres PegPronada	https://youtu.be/0K9NJHXYSm4	2024-04-23 20:32:48.253539	\N	f	\N
7a421333-b5cb-4b7b-a832-383bb6357569	Rosca Francesa Cross Corda	https://youtu.be/QhJ67UyNdsc	2024-04-23 20:32:48.253539	\N	f	\N
7e89d368-b0f7-4103-948e-fd0267fa3d7a	Elevação Frontal Halteres PegSupinada	https://youtu.be/DuUh84gcaso	2024-04-23 20:32:48.253539	\N	f	\N
86afeb8f-631a-4a31-b6b5-3b625e8689fa	ão Frontal Barra PegSupinada	https://youtu.be/Ea_8qpcysYI	2024-04-23 20:32:48.253539	\N	f	\N
87098575-1863-40bb-920c-66b891bbf81b	Remada Curvada Halteres PegPronada	https://youtu.be/AT8pPML17VU	2024-04-23 20:32:48.253539	\N	f	\N
882a0bc1-01aa-4271-bec4-ae6c46c9a063	Puxada Vertical Com Triângulo	https://youtu.be/ej9Z_jMQpLY	2024-04-23 20:32:48.253539	\N	f	\N
8a93507d-0ff7-4858-8523-344c9e97de32	Supino Reto Barra	https://youtu.be/sqOw2Y6uDWQ	2024-04-23 20:32:48.253539	\N	f	\N
8b1878da-54a1-4ac2-bf5e-7a3c826ed0f9	Pull-Down Barra	https://youtu.be/qw37xEEcoig	2024-04-23 20:32:48.253539	\N	f	\N
8e539a8f-11ec-404d-ad60-10a445a35d58	Encolhimento Halteres	https://youtu.be/ZzJ3zelC0qI	2024-04-23 20:32:48.253539	\N	f	\N
8eecae51-b35d-4177-bdd3-0c21c9801cfd	Remada Cross PegSupinada	https://youtu.be/Q5Rl_fnOCBs	2024-04-23 20:32:48.253539	\N	f	\N
8f891145-f565-4c9c-ad64-a58ced93581e	Pull-Down Cross Corda	https://youtu.be/zdLHXB9Sn88	2024-04-23 20:32:48.253539	\N	f	\N
92ca43de-24c2-4d5c-aaf1-aac3160c8b29	Crucifixo Inverso Cross	https://youtu.be/gWa5abtK4G4	2024-04-23 20:32:48.253539	\N	f	\N
985fe895-5e94-4078-aa6a-b2c1cb8a9065	Puxada Vertical PegPronada	https://youtu.be/H09EvebBsB4	2024-04-23 20:32:48.253539	\N	f	\N
9a5e919c-e60d-44c3-b9b2-d5afee2bb782	Desenvolvimento Máquina	https://youtu.be/oBF4YIwh_w8	2024-04-23 20:32:48.253539	\N	f	\N
9baeddb1-c4fb-496c-bca0-635794feffea	TrícepsCoice Unilateral Halteres	https://youtu.be/I4hzS9nYlgs	2024-04-23 20:32:48.253539	\N	f	\N
9d518ee7-d3e3-4c80-82fd-7f3f39becb72	Desenvolvimento Anterior	https://youtu.be/V_15VvJ3mr4	2024-04-23 20:32:48.253539	\N	f	\N
9ea2adcd-5664-4139-a8f8-db4c7ca97a90	Remada Curvada Cavalinho	https://youtu.be/Hdqf7mlEHrA	2024-04-23 20:32:48.253539	\N	f	\N
9ef58e9c-dbab-4b83-9254-75b7c3b2bc6c	Supino Inclinado Barra	https://youtu.be/lBCjPgnIzKk	2024-04-23 20:32:48.253539	\N	f	\N
9fa89cc6-1bb1-40b5-8c4e-c01b1a1ff10f	Rosca Francesa Halteres PegSupinada	https://youtu.be/KoLqZRyZuuU	2024-04-23 20:32:48.253539	\N	f	\N
a0b157fd-0eb7-4c37-ad39-f544f6b388ca	Elevação Lateral Cross Posterior	https://youtu.be/I-ywK8Q	2024-04-23 20:32:48.253539	\N	f	\N
a1cd8df5-61f3-454a-a569-e50198333f38	TrícepsCoice Bilateral Halteres	https://youtu.be/lbYQgZvJApA	2024-04-23 20:32:48.253539	\N	f	\N
a6da134e-e71a-47f9-a2ed-f8747f5e2708	Remada Cross Peg Neutra	https://youtu.be/wC1EsDy_esM	2024-04-23 20:32:48.253539	\N	f	\N
aa211ecd-5160-4658-bc37-2650eb56c1b4	Elevação Frontal Cross PegPronada	https://youtu.be/mOTjgenwgUc	2024-04-23 20:32:48.253539	\N	f	\N
ab01d2df-795c-487f-b017-5f41a08e7c36	Barra Fixa Com Triângulo	https://youtu.be/uCnm	2024-04-23 20:32:48.253539	\N	f	\N
ad239393-09e7-4da6-bdaf-07e320681ad2	Crucifixo Inverso Halteres	https://youtu.be/SLQZOByDo04	2024-04-23 20:32:48.253539	\N	f	\N
b09fadb6-3c51-495d-8eae-4750f013c68c	Tríceps PulleyPegPronada	https://youtu.be/QDt8P44ORa4	2024-04-23 20:32:48.253539	\N	f	\N
b62aab3a-ebb3-4108-bd89-16eccbeae03c	Remada Alta Barra	https://youtu.be/Z6jSLKXZ0Ag	2024-04-23 20:32:48.253539	\N	f	\N
b651b221-5047-43b6-a3c7-c8adc9839dd5	Tríceps Pulley Unilateral PegSupinada	https://youtu.be/iO5EOd9Xe4c	2024-04-23 20:32:48.253539	\N	f	\N
b768a485-a014-481f-bf2f-6ee7797857c9	Desenvolvimento Halteres	https://youtu.be/4pU	2024-04-23 20:32:48.253539	\N	f	\N
ba062dd3-7bde-4e80-a616-947163158f54	Rosca Testa Halteres PegPronada	https://youtu.be/esAavWMIRZ8	2024-04-23 20:32:48.253539	\N	f	\N
baf74c26-44ae-4227-9470-a8d93b897847	Supino Reto Smith	https://youtu.be/b-THwNtIYxY	2024-04-23 20:32:48.253539	\N	f	\N
bbb4381a-fad6-4936-a9c1-4fb13520d3aa	Tríceps PulleyPegSupinada	https://youtu.be/2W09NaNpiOA	2024-04-23 20:32:48.253539	\N	f	\N
bbe3bbc7-d7ac-4777-abcd-245e74c5fa76	Remada Unilateral Peg Neutra	https://youtu.be/C-tlPEhjwTk	2024-04-23 20:32:48.253539	\N	f	\N
be0e4e5d-ceca-4a56-92b0-895e550a3c16	Elevação Frontal Barra PegPronada	https://youtu.be/jXUIrrvlR_0	2024-04-23 20:32:48.253539	\N	f	\N
c3d345e1-c3b1-47f8-95e0-93178cb8d787	Crucifixo Declinado Halteres	https://youtu.be/QsZ8VYaRh34	2024-04-23 20:32:48.253539	\N	f	\N
c779c6e0-1c45-4f3c-8144-0ede081f2af2	Manguito Rotador Externo Halteres	https://youtu.be/2ecstA3a5f4	2024-04-23 20:32:48.253539	\N	f	\N
c9393904-823e-42b5-91f6-91db177de8df	Pull-Down Cross Peg Supinada	https://youtu.be/U80znmkD2z0	2024-04-23 20:32:48.253539	\N	f	\N
ce7a0fd6-0e28-40e3-a1cf-ec6e017f0626	Rosca Francesa Barra PegSupinada	https://youtu.be/xnP	2024-04-23 20:32:48.253539	\N	f	\N
cf38cb62-e6b7-4900-80f7-089fdbb1c752	Elevação Frontal Cross Corda	https://youtu.be/xCQLo6LcudM	2024-04-23 20:32:48.253539	\N	f	\N
d6703ef9-9c4b-4bb5-b686-2c2c0d9a1ae6	Rosca Francesa Barra PegPronada	https://youtu.be/fcIzvqXOJzs	2024-04-23 20:32:48.253539	\N	f	\N
d756dca4-8dc9-4903-96cb-12d2ba0fa701	Crucifixo Na Máquina	https://youtu.be/Ru9OVOUlp0U	2024-04-23 20:32:48.253539	\N	f	\N
d833ee89-fc22-4000-bae6-3256f0c3161b	Rosca Testa Halteres PegSupinada	https://youtu.be/OS8sz24YV1g	2024-04-23 20:32:48.253539	\N	f	\N
dd4994ed-a83e-4c5f-a3a8-4eb24800f886	Remada Máquina PegPronada	https://youtu.be/_g6GeyWVivI	2024-04-23 20:32:48.253539	\N	f	\N
de664167-5b74-497e-8fda-54fa63888086	Manguito Rotador Externo Barra	https://youtu.be/QdUn8TBdjvU	2024-04-23 20:32:48.253539	\N	f	\N
e092796c-e76f-4c1f-b4c1-397a7d07e5bf	Barra Fixa PegSupinada	https://youtu.be/WJOu_aru3XM	2024-04-23 20:32:48.253539	\N	f	\N
e09506f7-4d5e-4116-b7b1-c1882f1eaae9	Remada Curvada PegPronada	https://youtu.be/XruycmUNi1Y	2024-04-23 20:32:48.253539	\N	f	\N
e7ac17d2-9409-4575-8cda-19ce854705c2	Over Polia Média	https://youtu.be/iLRFLm82dbg	2024-04-23 20:32:48.253539	\N	f	\N
eae6d996-6f09-44ce-9287-c22ed83b14f0	Elevação Lateral Cross Anterior	https://youtu.be/8KOat8ZsidI	2024-04-23 20:32:48.253539	\N	f	\N
ed37caf8-6eff-410e-8e1a-cc4c34067f3d	Desenvolvimento Smith	https://youtu.be/oi18jaIbFRM	2024-04-23 20:32:48.253539	\N	f	\N
f0a1a61d-a651-4c5e-8e35-0fe4b625da05	Rosca Testa Barra PegPronada	https://youtu.be/orMEOzQjiAs	2024-04-23 20:32:48.253539	\N	f	\N
f1cc3379-1c1b-4540-bef8-846db9b288b3	Supino Declinado Halteres	https://youtu.be/0SFB2chQTPY	2024-04-23 20:32:48.253539	\N	f	\N
f1d9607d-ebfe-4291-a5cb-ee77a4053a3b	Over Polia Alta	https://youtu.be/HNUji0rHFCs	2024-04-23 20:32:48.253539	\N	f	\N
f3c7e10d-3717-4309-bd0d-4dfb7035949d	Remada Alta Halteres	https://youtu.be/hFMCum41W9c	2024-04-23 20:32:48.253539	\N	f	\N
f4c237dd-d4dd-4b2e-93e4-d4a643e3c5d1	Supino Declinado Barra	https://youtu.be/hZ9woVlzGdA	2024-04-23 20:32:48.253539	\N	f	\N
f6530b2e-9c49-4661-8365-79aef24f2bce	Elevação Lateral Unilateral Banco Inclinado	https://youtu.be/8s9JRhE95mU	2024-04-23 20:32:48.253539	\N	f	\N
f7ae3f74-d76e-46ef-87ef-a2576e1313c9	Elevação Frontal Cruzada	https://youtu.be/btAEYSe5kp0	2024-04-23 20:32:48.253539	\N	f	\N
f94e036c-2336-4fcc-b1d2-ec131b2ab5e0	Remada Curvada PegSupinada	https://youtu.be/y-XZnuKx3Q0	2024-04-23 20:32:48.253539	\N	f	\N
fb424551-e1a8-47d1-97ff-634e3f42c0ac	Crucifixo Inclinado Halteres	https://youtu.be/4JvT5Ys1Bog	2024-04-23 20:32:48.253539	\N	f	\N
fe8d8fe3-9b81-4ffb-91d5-f5e54b9e93f7	Tríceps Coice Unilateral Cross	https://youtu.be/MGlqvfSCWLQ	2024-04-23 20:32:48.253539	\N	f	\N
fece18af-7e9d-4551-bd6d-b427a4fc30c6	Remada Máquina Peg Neutra	https://youtu.be/C0-C0X7G8eQ	2024-04-23 20:32:48.253539	\N	f	\N
ff152906-0f1c-4751-b2b2-ff2e87c17b78	Remada Unilateral PegPronada	https://youtu.be/VlCc	2024-04-23 20:32:48.253539	\N	f	\N
\.


--
-- TOC entry 3372 (class 0 OID 90170)
-- Dependencies: 218
-- Data for Name: Sets; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Sets" ("Id", "Reps", "Series", "IntervalsInSeconds", "Weight", "AdvancedTechnique", "CreatedOnUtc", "UpdatedOnUtc", "IsDeleted", "DeletedOnUtc", "ExerciseId", "WorkoutId") FROM stdin;
518d9d41-0cee-4c41-a6e6-6e01760272b0	12	4	60	\N	\N	2024-04-23 20:42:59.130028	\N	f	\N	03a390e3-36b3-4f3d-8965-6280ee531f66	2bc335d3-875c-4e83-9820-625f4272b897
dec3f3b4-d3d2-4334-a295-a960d7e747a1	12	4	60	\N	\N	2024-04-23 20:42:59.130028	\N	f	\N	055076d1-b99b-48a6-96ac-d0af9f39fe7c	2bc335d3-875c-4e83-9820-625f4272b897
\.


--
-- TOC entry 3371 (class 0 OID 90157)
-- Dependencies: 217
-- Data for Name: Workout; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Workout" ("Id", "Title", "Type", "Observations", "CreatedOnUtc", "UpdatedOnUtc", "IsDeleted", "DeletedOnUtc", "WorkoutRoutineId") FROM stdin;
2bc335d3-875c-4e83-9820-625f4272b897	Treino de peitoral	\N	\N	2024-04-23 20:42:59.130028	\N	f	\N	e5c6d8d3-cfa9-4c1f-add2-2494836701d1
\.


--
-- TOC entry 3370 (class 0 OID 90149)
-- Dependencies: 216
-- Data for Name: WorkoutRoutine; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."WorkoutRoutine" ("Id", "StudentId", "Title", "Observations", "Active", "InactiveOnExpiration", "StartDate", "ExpirationDate", "CreatedOnUtc", "UpdatedOnUtc", "IsDeleted", "DeletedOnUtc") FROM stdin;
e5c6d8d3-cfa9-4c1f-add2-2494836701d1	445c095e-2f3c-4ae8-ae67-95db6fefacff	Treino de hipertrofia	\N	t	t	2024-04-25 20:40:52.81	2024-06-23 20:40:52.81	2024-04-23 20:41:23.785293	\N	f	\N
\.


--
-- TOC entry 3214 (class 2606 OID 90148)
-- Name: Exercise PK_Exercise; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Exercise"
    ADD CONSTRAINT "PK_Exercise" PRIMARY KEY ("Id");


--
-- TOC entry 3223 (class 2606 OID 90175)
-- Name: Sets PK_Sets; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sets"
    ADD CONSTRAINT "PK_Sets" PRIMARY KEY ("Id");


--
-- TOC entry 3219 (class 2606 OID 90164)
-- Name: Workout PK_Workout; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Workout"
    ADD CONSTRAINT "PK_Workout" PRIMARY KEY ("Id");


--
-- TOC entry 3216 (class 2606 OID 90156)
-- Name: WorkoutRoutine PK_WorkoutRoutine; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."WorkoutRoutine"
    ADD CONSTRAINT "PK_WorkoutRoutine" PRIMARY KEY ("Id");


--
-- TOC entry 3220 (class 1259 OID 90186)
-- Name: IX_Sets_ExerciseId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Sets_ExerciseId" ON public."Sets" USING btree ("ExerciseId");


--
-- TOC entry 3221 (class 1259 OID 90187)
-- Name: IX_Sets_WorkoutId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Sets_WorkoutId" ON public."Sets" USING btree ("WorkoutId");


--
-- TOC entry 3217 (class 1259 OID 90188)
-- Name: IX_Workout_WorkoutRoutineId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Workout_WorkoutRoutineId" ON public."Workout" USING btree ("WorkoutRoutineId");


--
-- TOC entry 3225 (class 2606 OID 90176)
-- Name: Sets FK_Sets_Exercise_ExerciseId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sets"
    ADD CONSTRAINT "FK_Sets_Exercise_ExerciseId" FOREIGN KEY ("ExerciseId") REFERENCES public."Exercise"("Id") ON DELETE CASCADE;


--
-- TOC entry 3226 (class 2606 OID 90181)
-- Name: Sets FK_Sets_Workout_WorkoutId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sets"
    ADD CONSTRAINT "FK_Sets_Workout_WorkoutId" FOREIGN KEY ("WorkoutId") REFERENCES public."Workout"("Id");


--
-- TOC entry 3224 (class 2606 OID 90165)
-- Name: Workout FK_Workout_WorkoutRoutine_WorkoutRoutineId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Workout"
    ADD CONSTRAINT "FK_Workout_WorkoutRoutine_WorkoutRoutineId" FOREIGN KEY ("WorkoutRoutineId") REFERENCES public."WorkoutRoutine"("Id") ON DELETE CASCADE;


-- Completed on 2024-05-01 11:29:54

--
-- PostgreSQL database dump complete
--

