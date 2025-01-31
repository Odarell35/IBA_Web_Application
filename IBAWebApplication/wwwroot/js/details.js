
document.addEventListener("DOMContentLoaded", function () {
    const steps = document.querySelectorAll(".step");
    let currentStep = parseInt(localStorage.getItem("currentStep")) || 0;

    function updateSteps() {
        steps.forEach((step, index) => {
            if (index <= currentStep) {
                step.classList.add("completed");
            } else {
                step.classList.remove("completed");
            }
        });
    }

    function completeNextStep() {
        if (currentStep < steps.length) {
            currentStep++;
            localStorage.setItem("currentStep", currentStep);
            updateSteps();
        }
    }

    updateSteps();
    document.getElementById("complete-step").addEventListener("click", completeNextStep);
});