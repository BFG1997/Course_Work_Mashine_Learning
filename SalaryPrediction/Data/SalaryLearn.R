#��������� ����
data <- read.csv2('data.csv', header=TRUE, sep=";")

#������ ������� ������� ��� �������
names(data) <- c("Profession", "Sex", "Region", "2005", "2007", "2009", "2011")
data$`2005` <- data$`2005`*1000
data$`2007` <- data$`2007`*1000
data$`2009` <- as.numeric(gsub(',','', data$`2009`))
data$`2011` <- as.numeric(gsub(',','', data$`2009`))
for(i in 1:nrow(data))
{
  if(data[i, "Profession"] != "") 
  {
    tmp = data[i, "Profession"]
  }
  if(data[i, "Profession"] == "")
  {
    data[i, "Profession"] = tmp
  }
}

for(i in 1:nrow(data))
{
  if(data[i, "Sex"] != "") 
  {
    tmp = data[i, "Sex"]
  }
  if(data[i, "Sex"] == "")
  {
    data[i, "Sex"] = tmp
  }
}
data[is.na(data)] <- 0
data$Profession <- as.factor(gsub("�����","All", data$Profession))
data$Sex <- as.factor(gsub("�����","All", data$Sex))
sapply(data, class)
#����� ��������� ������

#�������� ����� ������� "������� ��������"
#� ��������� �� �������� � ������� ������� mean
data$meanSalary <- 0
for(i in 1:nrow(data))
{
  data[i,"meanSalary"] <- mean(c(data[i, "2005"], data[i, "2007"], 
                                 data[i, "2009"], data[i, "2011"]), na.rm=FALSE)
}

data <- data[data$meanSalary > 0, ]
#����� ��������

#�������� �������� ������
lin.model.1 <- lm(meanSalary~Profession+Sex+Region, data=data)
plot(lin.model.1)
SalaryPredict <- predict(lin.model.1)
cor(data$meanSalary, SalaryPredict)
plot(data$meanSalary, SalaryPredict, col=c("red", "darkBlue"))