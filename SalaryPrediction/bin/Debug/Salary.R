#Считываем файл
data <- read.csv2('data.csv', header=TRUE, sep=";")

#Делаем датасет удобным для анализа
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
data <- data[data$`2005` > 1000, ]
data <- data[data$`2007` > 1000, ]
data <- data[data$`2009` > 1000, ]
data <- data[data$`2011` > 1000, ]
#data[is.na(data)] <- 0
data <- data[!is.na(data$`2005`) & !is.na(data$`2007`) &
               !is.na(data$`2009`) & !is.na(data$`2011`),]
data$Profession <- as.factor(gsub("Всего","All", data$Profession))
data$Sex <- as.factor(gsub("Всего","All", data$Sex))
#Конец обработки данных

#Создадим новую колонку "Средняя зарплата"
#и расчитаем ее значение с помощью функции mean
data$meanSalary <- 0
for(i in 1:nrow(data))
{
  data[i,"meanSalary"] <- mean(c(data[i, "2005"], data[i, "2007"], 
                                 data[i, "2009"], data[i, "2011"]), na.rm=TRUE)
}

data <- data[data$meanSalary > 1000, ]
#Конец рассчета

#Поиск выбросов и избавление от них
ind <- which(data$meanSalary %in% boxplot(data$meanSalary)$out)
data <- data[-ind,]
#Конец избавления от выбросов

#Конец краткого исследовательского анализа

#Создание линейной модели
lin.model.1 <- lm(meanSalary~Profession+Sex+Region, data=data)
unPr <- unique(data$Profession)
unSex <- unique(data$Sex)
unReg <- unique(data$Region)
dataFrameUnPr <- data.frame(seq(1:51), unPr)
names(dataFrameUnPr) <- c("N", "A")
dataFrameUnSex <- data.frame(seq(1:3), unSex)
names(dataFrameUnSex) <- c("N", "A")
dataFrameUnReg <- data.frame(seq(1:91), unReg)
names(dataFrameUnReg) <- c("N", "A")

