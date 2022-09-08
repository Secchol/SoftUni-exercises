function fixWorkerDizziness(worker) {
    if (worker.dizziness) {
        worker.levelOfHydrated += 0.1 * worker.experience * worker.weight;
        worker.dizziness = false;

    }
    return worker;
}
console.log(fixWorkerDizziness({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
  ));