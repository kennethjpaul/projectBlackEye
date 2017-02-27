from bs4 import BeautifulSoup

import requests
import re


#r  = requests.get("https://www.facebook.com/logical.indian/")
#r  = requests.get("https://www.facebook.com/nytimes/")
r  = requests.get("https://www.facebook.com/ScienceAlert/")


data = r.text

soup = BeautifulSoup(data, 'html.parser')

tag = soup.select('a[href^="https://l.facebook.com/"]')
#print(data)

result = []

for item in soup.find_all(attrs={'class' :'lfloat'}):
    for b in item.find_all('a'):
    	#print ("Found the URL:", b['href'])
    	for m in item.select('a[href^="https://l.facebook.com/"]'):
    		m1 = m['href'].replace("https://l.facebook.com/l.php?u=","",1)
    		m2 = re.sub(r'&.*$', "", m1)
    		m3 = re.sub(r'%3F.*$', "", m2)
    		m4 = m3.replace("%2F","/")
    		m5 = m4.replace("%3A",":")
    		#print(m1.rstrip('&'))
    		result.append(m5)
    		#print(m5)
    #

result = set(result)
seen = set()
result_final = []
for item in result:
    if item not in seen:
        seen.add(item)
        result_final.append(item)


for i in result_final:
	print(i)