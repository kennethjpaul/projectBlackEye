from bs4 import BeautifulSoup
from math import floor

import requests
import re


#r  = requests.get("https://www.facebook.com/logical.indian/")
r  = requests.get("https://www.facebook.com/nytimes/")
#r  = requests.get("https://www.facebook.com/ScienceAlert/")


data = r.text

soup = BeautifulSoup(data, 'html.parser')

tag = soup.select('a[href^="https://l.facebook.com/"]')
result = []

for item in soup.find_all(attrs={'class' :'lfloat'}):
    for b in item.find_all('a'):
        
        for m in item.select('a[href^="https://l.facebook.com/"]'):
    		
            m1 = m['href'].replace("https://l.facebook.com/l.php?u=","",1)
    		
            m2 = re.sub(r'&.*$', "", m1)
    		
            m3 = re.sub(r'%3F.*$', "", m2)
    		
            m4 = m3.replace("%2F","/")
    		
            m5 = m4.replace("%3A",":")
    		
            result.append(m5)
            result.append(m.get_text())


    for image in item.find_all('img'):
    	k1 = re.sub(r'&cfs.*$',"",image['src'])
    	k2 = re.sub(r'^https://scontent.*$',"",k1)
    	k3 = re.sub(r'.*url=',"",k2)
    	k4 = re.sub(r'%3F.*$', "", k3)
    	k5 = k4.replace("%2F","/")
    	k6 = k5.replace("%3A",":")
    	k7 = re.sub(r'.*\.gif',"",k6)
    	result.append(k7)



seen = set()
result_final = []
for item in result:
    if item not in seen:
        seen.add(item)
        result_final.append(item)

result_final = list(result_final)

for i in result_final:
	print(i)