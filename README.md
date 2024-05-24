Добрый день!

В задании не было сказано какую стоит использовать ORM, но было указано про SQL бд скрипт, поэтому решил использовать Dapper. В основном использую Entity Framework Core.

Скрипт базы данных запускается автоматически при docker compose, то есть, когда контейнеры будут подняты, в базе данных уже будут таблицы и данные.

Из проверок данных: только required от [ApiController] и ограничения, указанные при создании базы данных.

Запуск проекта довольно простой, для этого нужно:
  - выполнить клонирование репозитория
  - перейти в папку с решением проекта
  - выполнить docker compose up

После этого можно проверить и должно выдавать что-то в следующем роде:

![image](https://github.com/Valery-Soshin/SurveyDemo/assets/105991605/ca5d0b48-91e3-4485-94f2-24b62b4970a3)


![image](https://github.com/Valery-Soshin/SurveyDemo/assets/105991605/8b2306e4-3237-49f8-8253-f7552f10e1de)
