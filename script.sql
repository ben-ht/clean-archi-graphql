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
-- Name: Products_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Products_Id_seq"', 7, true);


--
-- Name: Products Products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "Products_pkey" PRIMARY KEY ("Id");


--
-- PostgreSQL database dump complete
--

