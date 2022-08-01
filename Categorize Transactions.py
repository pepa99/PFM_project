#!/usr/bin/env python
# coding: utf-8

# In[67]:


import sys
import numpy as np
from sklearn.feature_extraction.text import HashingVectorizer
from sklearn.linear_model import LogisticRegression
from sklearn.tree import DecisionTreeClassifier 
from sklearn.preprocessing import LabelEncoder, OneHotEncoder, OrdinalEncoder
from sklearn.compose import ColumnTransformer

lableencoder_X_1 = OrdinalEncoder(handle_unknown='use_encoded_value',unknown_value=-1)
lableencoder_X_2 = OrdinalEncoder(handle_unknown='use_encoded_value',unknown_value=-1)
def train():
 transformer=HashingVectorizer(stop_words='english')
 Y=[]
 f=open(r'C:\Users\Instructor\Desktop\PFM-project\PFM_project\transactions.csv')
 f2=open(r'C:\Users\Instructor\Desktop\PFM-project\PFM_project\train_labels.csv')
 text=f.readlines()[1:1000]
 prva=[]
 druga=[]
 treca=[]

 pom1=[]
 pom2=[]
 labels=f2.readlines()[1:1000]
 i=0
 pom3=[]
 ind=[]
 for lines in text:
    i+=1
    array=lines.split(",")
    prva.append(array[1])
    if len(array)==9:
            treca.append(array[5])
            druga.append(float(array[4]))
    else:
            druga.append(float(array[4][1:len(array[4])])*1000+float(array[5][0:len(array[5])-1]))             
            treca.append(array[6])
   
  
 i=0  
 y_test=[]
 for lines in labels:
    i+=1
    if i<1000:
        Y.append(int(lines.split(",")[1]))
    else:
        y_test.append(int(lines.split(",")[1]))
 ct = ColumnTransformer([('ohe', OneHotEncoder(), [1])], remainder='passthrough')        
 X=np.empty([len(prva),3],dtype=object)        
 X[:,0]=prva
 X[:,1]=treca
 X[:,2]=druga
 X[:, 1] = lableencoder_X_2.fit_transform(X[:, 1].reshape(-1, 1)).reshape(len(text))
 X[:, 0] = lableencoder_X_1.fit_transform(X[:, 0].reshape(-1, 1)).reshape(len(text))
 #print(X)
 clf = DecisionTreeClassifier()
 model=clf.fit(X,Y)
 
 f.close()
 f2.close()
 return model
# In[68]:
def test():
    f=open(r'C:\Users\Instructor\Desktop\PFM-project\PFM_project\transactions.csv')
    text=f.readlines()[1000:1304]
    prva=[]
    druga=[]
    treca=[]
    ind=[]
    for lines in text:
      array=lines.split(",")
      ind.append(array[0])
      prva.append(array[1])
      if len(array)==9:
            treca.append(array[5])
            druga.append(float(array[4]))
      else:
            druga.append(float(array[4][1:len(array[4])])*1000+float(array[5][0:len(array[5])-1]))             
            treca.append(array[6])
    X_test=np.empty([len(prva),3],dtype=object)
    X_test[:,0]=prva
    X_test[:,1]=treca   
    X_test[:,2]=druga
    X_test[:,0] = lableencoder_X_1.transform(X_test[:,0].reshape(-1,1)).reshape(len(text))
    X_test[:,1] = lableencoder_X_2.transform(X_test[:,1].reshape(-1,1)).reshape(len(text))

    test_label=train().predict(X_test)
    sum=0
    ml_file=open(r'C:\Users\Instructor\Desktop\PFM-project\PFM_project\ml.txt','w')

    for i in range(len(test_label)):
       print(test_label[i])
       ml_file.write(ind[i]+":"+str(test_label[i])+"\n")
       
train()         
test()

