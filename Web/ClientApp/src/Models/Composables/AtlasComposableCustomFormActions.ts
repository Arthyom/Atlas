import { router, useForm } from "@inertiajs/vue3";
import { useAtlasComposableLoadingCallbacks } from "./AtlasComposableLoadingCallbacks";
import { computed, ref } from "vue";
import { string } from "yup";
import axios from "axios";

const { opts } = useAtlasComposableLoadingCallbacks();

export const useAtlasComposableCustomFormActions = ( resource: string, isAdmin = true, formValues: any = null, initialValues: any = null, url: string | null = null ) => {
  const _formValues = ref( formValues )
  const _props = ref(initialValues);
  
  const _formConfs = computed( ()=> {  
    
    const hasId = _props.value?.mainResource?.id;

    const confs = {resource, url: ''}

    if(url){
      confs.url = url
      return confs
    }

    if(isAdmin && !url){
      if(!!hasId)
        confs.url = `/admin/${resource}/update/${hasId}`
      else
        confs.url = `/admin/${resource}/store`
    }
    else{
      if(!!hasId && !url)
        confs.url = `/store/${resource}/update/${hasId}`
      else
        confs.url = `/store/${resource}/store`
    }

      return confs;

    })



  const isSaveEnabled = computed(() => {
    if(_formConfs.value?.url.includes("update")){
      if (_props.value.extras) {
        if (!_props.value.extras.editable) return false;
  
        if (_props.value.extras.editable) return true;
      }
    }


    if( !_formValues.value.isValid ) return false

    if( _formValues.value?.isValid ) return true
  });

  // const pickedColor = computed( () => {
  //   if(_formValues?.value?.data?.color)
  //     return _formValues.value.data.color

  //   return '#00000'
  // })

  const cancelCustomForm = () => {
    router.get(`/admin/${_formConfs.value?.resource}/index`, {}, opts);
  };

  const submitCustomForm = () => {
    opts.onStart({});
    const f = { ..._formValues.value.data };

    const form = useForm(f);

    form.post(_formConfs.value?.url, {
      _method: "post",
      forceFormData: true,
      opts,
    });
  };

  const submitCustomFormWithData = (data:any) => {
    opts.onStart({});
    const f = { ...data};

    const form = useForm(f);

    form.post(_formConfs.value?.url, {
      _method: "post",
      forceFormData: true,
      opts,
    });
  };

  const submitCustomAjaxmWithData = async (data:any) => {

    try {
      
      opts.onStart({});
      const f = { ...data};
  
      // const form = useForm(f);
  
      // return form.post(_formConfs.value?.url, {
      //   _method: "post",
      //   // forceFormData: true,
      //   opts,
      // });
  
      const response = await axios.post(_formConfs.value.url , data)
      opts.onFinish({})
  
      return response;
      
    } catch (error) {
     opts.onError({}) 
    }

  };

  const setCustomFormValues = (formValues: any) => {
    _formValues.value = formValues
  };

  
  return {

    isSaveEnabled,


    submitCustomAjaxmWithData,
    cancelCustomForm,
    submitCustomForm,
    submitCustomFormWithData,
    setCustomFormValues,
    
  };
};
