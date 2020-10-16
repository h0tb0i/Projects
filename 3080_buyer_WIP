from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.wait import WebDriverWait
import time

PATH = "chromedriver.exe"

driver = webdriver.Chrome(PATH)

driver.get("welink")

search = driver.find_element_by_name("query")
search.send_keys("3080")
search.send_keys(Keys.RETURN)

try:
    prod_list = WebDriverWait(driver, 10).until(
        EC.presence_of_element_located((By.CLASS_NAME, "ais-Hits-list"))

    )

    product = prod_list.find_element_by_class_name("ais-Hits-item")

    status = product.find_element_by_class_name("stock-label").text

    while status != "IN STOCK":
        driver.refresh()

        status = WebDriverWait(driver, 10).until(
            EC.presence_of_element_located((By.CLASS_NAME, "stock-label"))

        )

        status = status.text
        print(status)

    link = product.find_element_by_tag_name("button")
    link.click()

    paypal = WebDriverWait(driver, 10).until(
        EC.presence_of_element_located((By.XPATH, "//iframe[@class='zoid-component-frame zoid-visible']"))

    )

    paypal.click()
    time.sleep(10)



finally:
    driver.quit()

