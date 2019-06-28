
import time
import sys
import os
import stomp

import json
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By
from webdriver_manager.chrome import ChromeDriverManager
from bs4 import BeautifulSoup

user = os.getenv("ACTIVEMQ_USER") or "admin"
password = os.getenv("ACTIVEMQ_PASSWORD") or "admin"
host = os.getenv("ACTIVEMQ_HOST") or "localhost"
port = os.getenv("ACTIVEMQ_PORT") or 61613
destination = sys.argv[1:2] or ["/topic/queue_name"]
destination = destination[0]

URL = 'https://www.metro.pe/'

def ocultar():
    options =  webdriver.ChromeOptions()
    options.add_argument('headless')
    options.add_experimental_option('excludeSwitches', ['enable-logging'])
    options.add_argument('--log-level=3')
    options.add_argument('--ignore-certificate-errors')
    options.add_argument("--disable-extensions")
    options.add_argument('disable-infobars')
    options.add_experimental_option( "prefs",{'profile.managed_default_content_settings.javascript': 2})       
    return options

def BusquedaPagina(producto):
    elemSearch = driver.find_element_by_id("search-autocomplete-input")
    elemSearch.send_keys(producto)
    elemSearch.send_keys(u'\ue007')

driver = webdriver.Chrome(executable_path='C:\\Users\\Kath\\Desktop\\chromedriver_win32\\chromedriver.exe',options=ocultar())
driver.get(URL)

class MyListener(object):
  
  def __init__(self, conn):
    self.conn = conn
    self.count = 0
    self.start = time.time()
  
  def on_error(self, headers, message):
    print('received an error %s' % message)

  def on_message(self, headers, message):
    if message != "" :
        print("entro")     
        print(message)
        BusquedaPagina(message)

        data = []
        ##sacar el sector ul y guardar ese source en una var
        soup = BeautifulSoup(driver.page_source,'lxml')
        divResultados = soup.find_all('div',{'class':'product-shelf'})

        soupResultado = BeautifulSoup(str(divResultados[0]),'lxml')
        resultList = soupResultado.find_all('li')
        i = 0
        
        for dat in resultList:
            nombre = dat.find('a',{'class':'product-item__name'}) 
            precio = dat.find('span',{'class':'product-prices__value product-prices__value--best-price'})
            img_url = dat.find('img')

            if nombre != None:
                data.append({
                    'idProducto' : i,
                    'nNombre' : nombre.get('title'),
                    'dImagen' : img_url.get('src'),
                    'nprecio': precio.getText()[2:]
                })
                i = i +1

        with open('data.json', 'w') as file:
            json.dump(data, file, indent=4)
        print("salio")
      
"""     if message == "SHUTDOWN":
    
      diff = time.time() - self.start
      print("Received %s in %f seconds" % (self.count, diff))
      conn.disconnect()
      sys.exit(0)
      
    else:
      if self.count==0:
        self.start = time.time()
        
      self.count += 1
      if self.count % 1000 == 0:
         print("Received %s messages." % self.count)
     """
conn = stomp.Connection(host_and_ports = [(host, port)])
conn.set_listener('', MyListener(conn))
conn.start()
conn.connect(login=user,passcode=password)
conn.subscribe(destination=destination,id =1 , ack='auto')
print("Waiting for messages...")
while 1: 
  time.sleep(10) 