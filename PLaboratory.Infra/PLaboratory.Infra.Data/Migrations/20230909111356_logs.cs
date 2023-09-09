using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLaboratory.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class logs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TABLE `AppLogs` (\r\n  `id` int NOT NULL AUTO_INCREMENT,\r\n  `Timestamp` varchar(100) DEFAULT NULL,\r\n  `Level` varchar(15) DEFAULT NULL,\r\n  `Template` text,\r\n  `Message` text,\r\n  `Exception` text,\r\n  `Properties` text,\r\n  `_ts` timestamp NULL DEFAULT CURRENT_TIMESTAMP,\r\n  PRIMARY KEY (`id`)\r\n) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE `LaboratoryDb`.`AppLogs`;");
        }
    }
}
