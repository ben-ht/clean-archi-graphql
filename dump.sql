--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
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
-- Name: Orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Orders" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "OrderDate" time with time zone NOT NULL,
    "TotalPrice" double precision NOT NULL
);


ALTER TABLE public."Orders" OWNER TO postgres;

--
-- Name: Orders_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Orders_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Orders_Id_seq" OWNER TO postgres;

--
-- Name: Orders_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Orders_Id_seq" OWNED BY public."Orders"."Id";


--
-- Name: Products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Products" (
    "Id" integer NOT NULL,
    "Name" character varying(255) NOT NULL,
    "Description" character varying(1000) NOT NULL,
    "Price" double precision NOT NULL,
    "Image" character varying(255) NOT NULL,
    "ProductType" integer NOT NULL
);


ALTER TABLE public."Products" OWNER TO postgres;

--
-- Name: Products_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Products" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Products_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" integer NOT NULL,
    "Username" character varying(255) NOT NULL,
    "Password" character varying(255) NOT NULL
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- Name: Users_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Users_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Users_Id_seq" OWNER TO postgres;

--
-- Name: Users_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Users_Id_seq" OWNED BY public."Users"."Id";


--
-- Name: Orders Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Orders" ALTER COLUMN "Id" SET DEFAULT nextval('public."Orders_Id_seq"'::regclass);


--
-- Name: Users Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users" ALTER COLUMN "Id" SET DEFAULT nextval('public."Users_Id_seq"'::regclass);


--
-- Data for Name: Orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Orders" ("Id", "UserId", "OrderDate", "TotalPrice") FROM stdin;
1	1	00:00:00+01	9
2	1	12:26:31.592876+01	3.5
3	1	12:46:06.515551+01	6.5
4	1	12:46:36.541227+01	2.5
5	1	12:49:54.43192+01	3.5
6	1	13:20:07.685501+01	2.75
7	1	14:21:41.836928+01	2.75
8	1	14:27:21.585741+01	3.5
9	1	14:30:08.399224+01	3.5
10	1	14:36:20.0494+01	3.5
11	1	14:37:12.417755+01	3.5
12	1	14:37:18.710763+01	3.5
13	1	14:43:14.208826+01	6
14	1	15:46:20.397764+01	3.75
15	1	16:01:40.192866+01	12
16	1	16:10:13.842411+01	3.5
17	1	16:10:38.133326+01	3.5
18	1	16:11:02.395012+01	3.5
19	1	16:16:24.438111+01	3.5
20	1	16:20:05.27729+01	3.5
21	1	16:20:37.238894+01	3.5
22	1	16:21:11.047358+01	3.5
23	1	16:21:37.51951+01	3.5
24	1	16:22:31.312107+01	3.5
\.


--
-- Data for Name: Products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Products" ("Id", "Name", "Description", "Price", "Image", "ProductType") FROM stdin;
1	Espresso	A strong and bold coffee shot.	2.5	espresso.jpg	0
2	Latte	A creamy coffee with steamed milk.	3.5	latte.jpg	0
3	Cappuccino	A classic coffee with frothy milk.	3.75	cappuccino.jpg	0
4	Americano	A smooth coffee diluted with water.	2.75	americano.jpg	0
5	Hot Milk	A cup of warm milk.	1.5	hot_milk.jpg	1
6	Hot Chocolate	Warm milk with rich chocolate flavor.	3	hot_chocolate.jpg	1
\.


--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("Id", "Username", "Password") FROM stdin;
1	string	string
\.


--
-- Name: Orders_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Orders_Id_seq"', 24, true);


--
-- Name: Products_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Products_Id_seq"', 7, true);


--
-- Name: Users_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_Id_seq"', 1, true);


--
-- Name: Orders Orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "Orders_pkey" PRIMARY KEY ("Id");


--
-- Name: Products Products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "Products_pkey" PRIMARY KEY ("Id");


--
-- Name: Users Users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("Id");


--
-- Name: Orders fk_userid; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT fk_userid FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") NOT VALID;


--
-- PostgreSQL database dump complete
--

