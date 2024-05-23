![image](https://github.com/tostmeister/WearShopX/assets/112758747/b6132a65-3263-44ed-9c18-5849bcd7cda9)
# 2.1 Описание приложения
***

Система предназначена для покупок продуктов питания, и подсчета пробитого товара на кассе.

Система имеет функционал:
- Отображение всего ассортимента в зале
- Добавление товаров в корзину по нажатию ЛКМ на кнопку “Добавить в корзину”
- Отображение окна “Заказ” по нажатию ЛКМ на кнопку “Оформить заказ”
- Отображение итоговой стоимости и отображение всех товаров в корзине
- Отображение всего ассортимента на складе
- Добавление, редактирование, удаление, перемещение в зал элеметов склада
  
# Работа приложения
***

Старт программы, отображение всего ассортимента и корзины:

![image](https://github.com/tostmeister/WearShopX/assets/112758747/0c8e486f-c1ee-4a37-84a6-b5cf5dde07d8)

Окно склада:

![image](https://github.com/tostmeister/WearShopX/assets/112758747/0f6b9f82-2f9a-49f5-944f-94ae4acf1dd5)

Окно добавления элемента на склад:
![image](https://github.com/tostmeister/WearShopX/assets/112758747/3d6e3a02-b3c2-463c-9205-2cb761e8d2a5)

***

Окно редактирования элемента на складе:
![image](https://github.com/tostmeister/WearShopX/assets/112758747/16d4a154-08d4-4ecd-ab87-ee9a6cfb9c0f)

Окно чека:
***
![image](https://github.com/tostmeister/WearShopX/assets/112758747/e63bb64c-6101-445e-ac23-1547bd278f34)

***


***
P.S.(запуск проекта)

1. Запустить приложение MS SQL Server Management Studio(установить, если отсутствует)

2. Скопировать и выполнить прикрепленный скрипт базы данных Это база.sql

3. Открыть решение проекта WpfApp3.sln 

4. Установить пакет NuGet Microsoft.EntityFrameworkCore;

5. Добавить в решение модель(новый элемент) ADO.NET EDM

6. Нажмите создать соединение и в открывшемся окне введите имя сервера, на котором была создана база данных из скрипта, выберите базу, затем нажмите «ок» 


![image](https://user-images.githubusercontent.com/116517177/231429343-2be5c44a-34a3-4a81-88c8-d81c5114aa70.png)

7. Введите имя которое будет сохранено в конфиге и нажмите «далее»

![image](https://user-images.githubusercontent.com/116517177/231429725-90fb0a4e-4f92-46b7-aa3e-49158fbc2ab5.png)

8. Поставьте галочку напротив «таблицы», введите название пространства имен и нажмите «готово»

![image](https://user-images.githubusercontent.com/116517177/231429804-f6880ce6-d8d4-4cfb-88bb-7ba0855b5d62.png)

9. В обозревателе решений перейдите в класс HR_Base.Context.cs

![image](https://user-images.githubusercontent.com/116517177/231430047-f9d8a569-e45b-43f4-9f45-99cd5432ba1d.png)

10. В нём потребуется реализовать паттерн Singleton

![image](https://user-images.githubusercontent.com/116517177/231430121-f1324515-300a-4ee8-8ee1-528d55e1e2a4.png)

11. Переведите сборку в «Release»

![image](https://user-images.githubusercontent.com/116517177/231430186-2a1f835c-59cc-4cb7-ae57-7a2c5bef1408.png)

12. Нажмите ПКМ по названию проекта в обозревателе решений и нажмите «собрать», или используйте сочетание клавиш Ctrl + Shift + B

![image](https://user-images.githubusercontent.com/116517177/231430242-01c1316d-0c2f-4d1d-b912-f3d11153c359.png)
