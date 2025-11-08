CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE "Ingredients" (
    "Id" uuid NOT NULL,
    "Name" character varying(255) NOT NULL,
    "Сalories" double precision,
    "Proteins" double precision,
    "Carbs" double precision,
    "Fats" double precision,
    "CreateDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Ingredients" PRIMARY KEY ("Id")
);

CREATE TABLE "Recipes" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "MainImageId" uuid,
    "Name" character varying(255) NOT NULL,
    "DefaultPortionSize" double precision NOT NULL,
    "Description" character varying(1000),
    "CookingTimeMinutes" integer NOT NULL,
    "Complexity" integer NOT NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Recipes" PRIMARY KEY ("Id")
);

CREATE TABLE "RecipeImages" (
    "Id" uuid NOT NULL,
    "RecipeId" uuid NOT NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_RecipeImages" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_RecipeImages_Recipes_RecipeId" FOREIGN KEY ("RecipeId") REFERENCES "Recipes" ("Id") ON DELETE CASCADE
);

CREATE TABLE "RecipesIngredients" (
    "RecipeId" uuid NOT NULL,
    "IngredientId" uuid NOT NULL,
    "Grams" double precision NOT NULL,
    CONSTRAINT "PK_RecipesIngredients" PRIMARY KEY ("RecipeId", "IngredientId"),
    CONSTRAINT "FK_RecipesIngredients_Ingredients_IngredientId" FOREIGN KEY ("IngredientId") REFERENCES "Ingredients" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_RecipesIngredients_Recipes_RecipeId" FOREIGN KEY ("RecipeId") REFERENCES "Recipes" ("Id") ON DELETE CASCADE
);

CREATE TABLE "RecipeSteps" (
    "Id" uuid NOT NULL,
    "RecipeId" uuid NOT NULL,
    "StepNumber" integer NOT NULL,
    "Description" character varying(1000) NOT NULL,
    "ImageId" uuid,
    "CreateDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_RecipeSteps" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_RecipeSteps_Recipes_RecipeId" FOREIGN KEY ("RecipeId") REFERENCES "Recipes" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_RecipeImages_RecipeId" ON "RecipeImages" ("RecipeId");

CREATE INDEX "IX_RecipesIngredients_IngredientId" ON "RecipesIngredients" ("IngredientId");

CREATE INDEX "IX_RecipeSteps_RecipeId" ON "RecipeSteps" ("RecipeId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250823090445_Initial', '9.0.7');

COMMIT;

