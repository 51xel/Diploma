# Інструкція для нових розробників

Це покрокова інструкція для налаштування робочого середовища. Виконуйте кожен крок у порядку.

## 1. Встановлення IDE

Для розробки потрібно вибрати одну з наступних IDE:

- **Visual Studio**
- **Rider**
- **VS Code**

Скачати та встановити можна за посиланням:
- [Visual Studio](https://visualstudio.microsoft.com/)
- [Rider](https://www.jetbrains.com/rider/)
- [VS Code](https://code.visualstudio.com/)

## 2. Встановлення Docker та WSL (для Windows)

Якщо ви працюєте на Windows, вам потрібно встановити наступні інструменти:

- **Docker Desktop**: [Завантажити Docker Desktop](https://www.docker.com/products/docker-desktop)
- **WSL (Windows Subsystem for Linux)**: для цього скористайтесь інструкціями на офіційному сайті [Microsoft](https://docs.microsoft.com/en-us/windows/wsl/install).

Рекомендую Ubuntu

## 3. Встановлення Azure CLI

Встановіть **Azure CLI** для взаємодії з вашими Azure-ресурсами. Для цього виконайте наступні кроки:

1. Перейдіть на [офіційний сайт Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) і слідуйте інструкціям для вашої операційної системи.

## 4. Авторизація в IDE через CLI

Авторизуйтеся в **Azure CLI** через вашу IDE. Для цього відкрийте термінал і виконайте команду:

```bash
az login
```

Це відкриє вікно браузера для введення облікових даних.

## 5. Клонування репозиторію

Клонуйте репозиторій з GitHub за допомогою команди:

```bash
git clone https://github.com/51xel/Diploma
```

## 6. Налаштування середовища (якщо не використовуєте Docker)

Якщо ви запускаєте проєкт без використання Docker, вам потрібно виконати наступні кроки:

1. Переконайтесь, що на вашій системі встановлено Python 3.11.
2. Створіть змінну середовища PYTHONNET_PYDLL та вкажіть шлях до Python DLL (наприклад):

```bash
C:\Users\User\AppData\Local\Programs\Python\Python312\python312.dll
```

3. Також потрібно встановити бібліотеку:
```bash
pip install joblib
```

## 7. Запуск

1. Відкрийте папку репозиторію в IDE
2. Виберіть Diploma solution
3. Виберіть проект, який хочете запустити (наприклад):

```bash
Diploma.PredictionApi
```

4. Виберіть спосіб запуску (Docker)
5. Запустіть проект (F5)

## Доступи

Після авторизації в Azure CLI в Azure у вас мають бути налаштовані всі доступи, тому додатково нічого вводити не треба
