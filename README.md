# Locação de Moto

# Scripts

CREATE TABLE IF NOT EXISTS public.deliveryman
(
    identifier character varying(60) COLLATE pg_catalog."default" NOT NULL,
    name character varying(120) COLLATE pg_catalog."default" NOT NULL,
    cnpj character varying(18) COLLATE pg_catalog."default" NOT NULL,
    cnh_number character varying(20) COLLATE pg_catalog."default" NOT NULL,
    cnh_type character varying(2) COLLATE pg_catalog."default" NOT NULL,
    cnh_image character varying(200) COLLATE pg_catalog."default",
    dateofbirth date,
    CONSTRAINT deliveryman_pkey PRIMARY KEY (identifier)
);

CREATE TABLE IF NOT EXISTS public.motto
(
    identifier character varying(80) COLLATE pg_catalog."default" NOT NULL,
    model character varying(80) COLLATE pg_catalog."default" NOT NULL,
    license_plate character varying(10) COLLATE pg_catalog."default" NOT NULL,
    year integer NOT NULL,
    CONSTRAINT "Motto_pkey" PRIMARY KEY (identifier)
)

CREATE TABLE IF NOT EXISTS public.rental
(
    id integer NOT NULL DEFAULT nextval('rental_id_seq'::regclass),
    date_created date NOT NULL,
    start_date date NOT NULL,
    end_date date,
    expected_end_date date NOT NULL,
    motto_id character varying(80) COLLATE pg_catalog."default" NOT NULL,
    deliveryman_id character varying(60) COLLATE pg_catalog."default" NOT NULL,
    plan integer NOT NULL,
    CONSTRAINT rental_pkey PRIMARY KEY (id),
    CONSTRAINT rental_deliveryman_deliveryman_id FOREIGN KEY (deliveryman_id)
        REFERENCES public.deliveryman (identifier) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT "rental_motto_moto_Id" FOREIGN KEY (motto_id)
        REFERENCES public.motto (identifier) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)



