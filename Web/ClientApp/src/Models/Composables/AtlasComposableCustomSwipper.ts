import type { SwiperContainer } from "swiper/element";
import { computed, ref, useTemplateRef } from "vue";

export const AtlasComposableCustomSwipper = (selector: string) => {
  const _swipper = useTemplateRef<SwiperContainer>(selector)

  const _step = ref(1);

  const swipeNext = () => {
    _swipper.value?.swiper.slideNext();
    _step.value++;
  };

  const swipePrev = () => {
    _swipper.value?.swiper.slidePrev();
    _step.value--;
  };    

  const step = computed( () => _step.value)

  return {
    step,
    
    swipeNext,
    swipePrev
  };
};
