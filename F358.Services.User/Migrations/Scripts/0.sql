CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE "Users" (
    "Id" uuid NOT NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    "Login" character varying(255) NOT NULL,
    "PasswordEncrypted" bytea NOT NULL,
    "EncryptionVersion" integer NOT NULL,
    "FirstName" character varying(255) NOT NULL,
    "LastName" character varying(255),
    CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250815155948_Initial', '9.0.7');

CREATE INDEX "IX_Users_Login" ON "Users" ("Login") INCLUDE ("Id", "PasswordEncrypted", "EncryptionVersion");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250817083708_AddIndexOnUsers', '9.0.7');

COMMIT;

