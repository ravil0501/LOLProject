function Simulate(heroAd, heroAttackSpeed, heroCrit) {
    var hp = parseFloat(document.getElementById("hpInput").value);
    var fullHp = hp;
    var armor = parseFloat(document.getElementById("armorInput").value);
    var iterations = parseFloat(document.getElementById("iterationsInput").value);
    var sum = 0.0001;
    var damage = 0.01;
    var speed = 0.01;
    var time = 0.01;
    var averageDamage = 0.01;
    var allTime = 0.01;
    for (var i = 0; i < iterations; i++) {
        while (hp > 0) {
            var random = Math.floor(Math.random() * (100 - 1 + 1)) + 1;
            if (heroCrit != 0) {
                if (random < heroCrit) {
                    damage = heroAd * (100 / (100 + armor) * 1.75)
                }
            }
            else {
                damage = heroAd * (100 / (100 + armor))
            }
            while (speed < heroAttackSpeed) {
                
                speed += 0.05;
                time += speed;
            }
            hp -= damage;
            sum += damage;
        }
        averageDamage += sum;
        allTime += time;
    }
    averageDamage /= iterations;
    allTime /= iterations;
    var resultDamage = document.getElementById("damage");
    var resultTime = document.getElementById("time");
    resultDamage.textContent ="Средний урон" + averageDamage;
    resultTime.textContent = "Время" + allTime;
}